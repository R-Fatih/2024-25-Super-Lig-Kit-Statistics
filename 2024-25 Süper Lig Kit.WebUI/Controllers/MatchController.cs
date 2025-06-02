using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.Dto.MatchDtos;
using _2024_25_Süper_Lig_Kit.Dto.RefereeDtos;
using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using _2024_25_Süper_Lig_Kit.WebUI.Models;
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
        public async Task<IActionResult> Index(string? week)
        {
            var client = _client.CreateClient("Default");
            if (week != null)
            {
                var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches?week={week}");
                return View(matches);
            }
            return View(new List<ResultMatchDto>());
        }
        [Route("Match/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _client.CreateClient("Default");
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches/GetMatchesByTeam?teamId={id}");
            return View(matches);
        }

        public async Task<IActionResult> TeamStatistics()
        {
            return View();
        }
        public async Task<IActionResult> TeamsDownByDown()
        {
            return View();
        }
        public async Task<IActionResult> TeamsDownByDownGK()
        {
            return View();
        }

        public async Task<IActionResult> GetMatchesByTeam(int id)
        {
            var client = _client.CreateClient("Default");
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches/GetMatchesByTeam?teamId={id}");
            ViewBag.id = id;
            return View(matches);
        }
        public async Task<IActionResult> GetMatchesByTeamJson(int id)
        {
            var client = _client.CreateClient("Default");
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches/GetMatchesByTeam?teamId={id}");
            ViewBag.id = id;
            return Json(matches);
        }
        public async Task<IActionResult> Referee(int id)
        {
            var client = _client.CreateClient("Default");
            var matches = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches/GetMatchesByReferee?refereeId={id}");
            return View("Index", matches);
        }

        public async Task<IActionResult> CrossTable()
        {
            var client = _client.CreateClient("Default");
            var match = await client.GetFromJsonAsync<List<Class1>>($"/api/Matches/CrossTable\r\n");
            return View(match);
        }
        public async Task<IActionResult> CrossTable2()
        {
            var client = _client.CreateClient("Default");
            var match = await client.GetFromJsonAsync<List<Class1>>($"/api/Matches/CrossTable\r\n");
            return Json(match);
        }

        public async Task<IActionResult> TeamDown()
        {
            var client = _client.CreateClient("Default");
            var match = await client.GetFromJsonAsync<List<TeamDownDto>>($"/api/Matches/GetAllTeamsKitsWeeks");
            return Json(match);
        }
        public async Task<IActionResult> TeamDownGK()
        {
            var client = _client.CreateClient("Default");
            var match = await client.GetFromJsonAsync<List<TeamDownDto>>($"/api/Matches/GetAllTeamsKitsWeeksGK");
            return Json(match);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var client = _client.CreateClient("Default");
            ViewBag.Teams = new SelectList(await client.GetFromJsonAsync<List<Team>>("/api/Teams"), "TeamId", "Name");
            ViewBag.RefereeJerseyImageId = new SelectList(await client.GetFromJsonAsync<List<ResultJerseyDto>>("/api/Teams/GetKitsByTeam?teamId=20"), "Id", "Name");
            ViewBag.Referees = new SelectList(await client.GetFromJsonAsync<List<ResultRefereeDto>>("/api/Referees"), "RefereeId", "RefereeName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMatchDto match)
        {
            if (match.Maçkolik != null)
            {

                var matchtemp = await Maçkolik(match.Maçkolik);
                match.Date = matchtemp.Date;
                match.HomeMS = matchtemp.HomeMS;
                match.AwayMS = matchtemp.AwayMS;

            }
            match.HomeTeamJerseyImageGKId = int.Parse(match.hg);
            match.HomeTeamJerseyImageId = int.Parse(match.hp);
            match.RefereeJerseyImageId = int.Parse(match.rf);
            match.AwayTeamJerseyImageId = int.Parse(match.ap);
            match.AwayTeamJerseyImageGKId = int.Parse(match.ag);

            var base64Data = Regex.Match(match.canvasData, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            // Dosyayı kaydet
            System.IO.File.WriteAllBytes($"D:\\2024-25 Sezonu\\Main\\{match.MainId}.png", imageBytes);


            var client = _client.CreateClient("Default");
            var response = await client.PostAsJsonAsync("/api/Matches", new Match
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
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.id = id;
            return View(new UpdateMatchDto { MatchId = id });
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMatchDto dto)
        {
            var client = _client.CreateClient("Default");
            var responseMessage = await client.PutAsJsonAsync($"/api/Matches", dto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetRemain()
        {
            var client = _client.CreateClient("Default");
            var jerseys = await client.GetFromJsonAsync<List<ResultMatchDto>>($"/api/Matches/RemainingMatches");

            var a = (jerseys, new UpdateMatchDto());
            return View(a);

        }

        [HttpPost]
        public async Task<IActionResult> GetRemain([Bind(Prefix = "Item1")] List<ResultMatchDto> match1, [Bind(Prefix = "Item2")] UpdateMatchDto matchdto)
        {

            var client = _client.CreateClient("Default");
            var responseMessage = await client.PutAsJsonAsync($"/api/Matches", matchdto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpGet]
        public async Task<ActionResult> GetHomeTeamJerseyGK(int homeTeamId)
        {
            var client = _client.CreateClient("Default");
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyDto>>($"/api/Teams/GetKeeperJerseysByTeam?teamId={homeTeamId}");
            var jerseysPlayer = await client.GetFromJsonAsync<List<ResultJerseyDto>>($"/api/Teams/GetKitsByTeam?teamId={homeTeamId}");

            // Takım ID'sine göre formaları alın
            return Json(new { Player = jerseysPlayer, GoalKeeper = jerseys });
        }
        [HttpGet]
        public async Task<ActionResult> GetHomeKitJerseyById(int homeTeamId)
        {
            var client = _client.CreateClient("Default");

            // Takım ID'sine göre formaları alın
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyImageDto>>($"/api/Teams/GetKitImagesByKit?kitid={homeTeamId}");
            return Json(jerseys);
        }
        [HttpGet]
        public async Task<ActionResult> GetHomeTeamJersey(int homeTeamId)
        {
            var client = _client.CreateClient("Default");

            // Takım ID'sine göre formaları alın
            var jerseys = await client.GetFromJsonAsync<List<ResultJerseyDto>>($"/api/Teams/GetKitsByTeam?teamId={homeTeamId}");

            return Json(jerseys);
        }

        public IActionResult RefWeek()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetRefWeek()
        {
            var client = _client.CreateClient("Default");

            // Takım ID'sine göre formaları alın
            var jerseys = await client.GetFromJsonAsync<List<RefereeKitDto>>($"/api/Matches/RefereeWeek");

            return Json(jerseys);
        }
        public async Task<ResultMatchDto> Maçkolik(int? id)
        {
            var client = _client.CreateClient("Default");
            var responseMessage = await client.GetAsync($"/api/Mackoliks/get?adres={id}");
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
