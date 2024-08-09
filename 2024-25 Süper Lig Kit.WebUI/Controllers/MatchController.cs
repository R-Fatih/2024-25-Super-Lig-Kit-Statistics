using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class MatchController : Controller
    {
        private readonly IHttpClientFactory _client;

        public MatchController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Create()
        {
            var client = _client.CreateClient();
            ViewBag.Teams = new SelectList(await client.GetFromJsonAsync<List<Team>>("https://localhost:7245/api/Teams"), "TeamId", "Name");

            return View();
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
    }
}
