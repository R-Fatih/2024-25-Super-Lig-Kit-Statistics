using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _client;

        public TeamController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var client= _client.CreateClient("Default");
             var response=await client.GetFromJsonAsync<List<Team>>("/api/teams");

            return View(response);
        }

        public async Task<IActionResult> SeasonSummary()
        {
            var client = _client.CreateClient("Default");
            
            try
            {
                var response = await client.GetAsync("https://localhost:7245/api/Statics/GetAllTeams");
                var jsonString = await response.Content.ReadAsStringAsync();
                
                // JSON'ı manual parse et
                var jsonDoc = JsonDocument.Parse(jsonString);
                var teams = new List<dynamic>();
                
                foreach (var element in jsonDoc.RootElement.EnumerateArray())
                {
                    teams.Add(new
                    {
                        teamId = element.GetProperty("teamId").GetInt32(),
                        teamName = element.GetProperty("teamName").GetString(),
                        teamLogo = element.TryGetProperty("teamLogo", out var logo) ? logo.GetString() : ""
                    });
                }
                
                ViewBag.Teams = teams;
            }
            catch (Exception ex)
            {
                ViewBag.Teams = new List<dynamic>();
                ViewBag.Error = "Takım listesi yüklenirken hata oluştu: " + ex.Message;
            }
            
            return View();
        }

        public async Task<IActionResult> GetTeamSeasonSummary(int teamId)
        {
            var client = _client.CreateClient("Default");
            
            try
            {
                var response = await client.GetAsync($"https://localhost:7245/api/Statics/GetTeamSeasonSummary/{teamId}");
                var jsonString = await response.Content.ReadAsStringAsync();
                
                // JSON string'i direkt return et, client-side'da parse edilecek
                return Content(jsonString, "application/json");
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto team)
        {
            
                var client= _client.CreateClient("Default");
                var response=await client.PostAsJsonAsync("/api/teams",team);

                // Takım oluşturma işlemi
                return RedirectToAction("Index");
            
            return View(team);
        }

        // Update action
        public IActionResult Update(int id)
        {
            // Güncellenecek takımı bul
            var team = new Team(); // Bu örnekte boş bir takım nesnesi kullanıyoruz
            return View(team);
        }

        [HttpPost]
        public IActionResult Update(Team team)
        {
            if (ModelState.IsValid)
            {
                // Takım güncelleme işlemi
                return RedirectToAction("Index");
            }
            return View(team);
        }
    
}
}
