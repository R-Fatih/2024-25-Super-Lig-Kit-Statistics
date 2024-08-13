using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.Dto.MatchDtos;
using _2024_25_Süper_Lig_Kit.Dto.RefereeDtos;
using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text.RegularExpressions;
using Match = _2024_25_Süper_Lig_Kit.WebUI.Entities.Match;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _client;

        public MatchController(IHttpClientFactory client)
        {
            _client = client;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _client.CreateClient();
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>("https://localhost:7245/api/Matches");
            return View(matches);
        }
        [Route("Match/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _client.CreateClient();
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"https://localhost:7245/api/Matches/GetMatchesByTeam?teamId={id}");
            return View(matches);
        }


        public async Task<IActionResult> GetMatchesByTeam(int id)
        {
            var client = _client.CreateClient();
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"https://localhost:7245/api/Matches/GetMatchesByTeam?teamId={id}");
            ViewBag.id = id;
            return View(matches);
        }

        public async Task<IActionResult> Referee(int id)
        {
            var client = _client.CreateClient();
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"https://localhost:7245/api/Matches/GetMatchesByReferee?refereeId={id}");
            return View("Index",matches);
        }

        public async Task<IActionResult> CrossTable()
        {
            var client = _client.CreateClient();
            var match = await client.GetFromJsonAsync<List<Class1>>($"https://localhost:7245/api/Matches/CrossTable\r\n");
            return View(match);
        }
        public async Task<IActionResult> CrossTable2()
        {
            var client = _client.CreateClient();
            var match = await client.GetFromJsonAsync<List<Class1>>($"https://localhost:7245/api/Matches/CrossTable\r\n");
            return Json(match);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _client.CreateClient();
            ViewBag.Teams = new SelectList(await client.GetFromJsonAsync<List<Team>>("https://localhost:7245/api/Teams"), "TeamId", "Name");
            ViewBag.RefereeJerseyImageId = new SelectList(await client.GetFromJsonAsync<List<ResultJerseyDto>>("https://localhost:7245/api/Teams/GetKitsByTeam?teamId=20"), "Id", "Name");
            ViewBag.Referees = new SelectList(await client.GetFromJsonAsync<List<ResultRefereeDto>>("https://localhost:7245/api/Referees"), "RefereeId", "RefereeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatchDto match)
        {
            var matchtemp = await Maçkolik(match.Maçkolik);
            match.Date = matchtemp.Date;
            match.HomeMS = matchtemp.HomeMS;
            match.AwayMS = matchtemp.AwayMS;

            match.HomeTeamJerseyImageGKId= int.Parse(match.hg);
            match.HomeTeamJerseyImageId = int.Parse(match.hp);
            match.RefereeJerseyImageId = int.Parse(match.rf);
            match.AwayTeamJerseyImageId = int.Parse(match.ap);
            match.AwayTeamJerseyImageGKId = int.Parse(match.ag);

            var base64Data = Regex.Match(match.canvasData, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            // Dosyayı kaydet
            System.IO.File.WriteAllBytes($"D:\\2024-25 Sezonu\\Main\\{match.MainId}.png", imageBytes);


            var client = _client.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7245/api/Matches", new Match
            {
                AwayMS = match.AwayMS,
                AwayTeamId = match.AwayTeamId,
                AwayTeamJerseyImageGKId = match.AwayTeamJerseyImageGKId,
                AwayTeamJerseyImageId = match.AwayTeamJerseyImageId,
                Date = match.Date,
                HomeMS = match.HomeMS,
                HomeTeamId = match.HomeTeamId,
                HomeTeamJerseyImageGKId = match.HomeTeamJerseyImageGKId,
                HomeTeamJerseyImageId = match.HomeTeamJerseyImageId,
                MainId = match.MainId,
                RefereeId = match.RefereeId,
                RefereeJerseyImageId = match.RefereeJerseyImageId,
                Week = match.Week,
                Maçkolik = match.Maçkolik,
                
            });
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(match);
        }


        [HttpGet]
        public async Task< ActionResult> GetHomeTeamJerseyGK(int homeTeamId)
        {
            var client = _client.CreateClient();
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyDto>>($"https://localhost:7245/api/Teams/GetKeeperJerseysByTeam?teamId={homeTeamId}");

            // Takım ID'sine göre formaları alın
            return Json(jerseys);
        }
        [HttpGet]
        public async Task<ActionResult> GetHomeKitJerseyById(int homeTeamId)
        {
            var client = _client.CreateClient();

            // Takım ID'sine göre formaları alın
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyImageDto>>($"https://localhost:7245/api/Teams/GetKitImagesByKit?kitid={homeTeamId}");
            return Json(jerseys);
        }
        [HttpGet]
        public async Task<ActionResult> GetHomeTeamJersey(int homeTeamId)
        {
            var client = _client.CreateClient();

            // Takım ID'sine göre formaları alın
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyDto>>($"https://localhost:7245/api/Teams/GetKitsByTeam?teamId={homeTeamId}");

            return Json(jerseys);
        }

        public async Task<ResultMatchDto> Maçkolik(int? id)
        {
            var client = _client.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7245/api/Mackoliks/get?adres={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMatchDto>(jsonData);



                return values;
            }

            // ViewBag.kits = teams;

            return null;
        }

    }
}
