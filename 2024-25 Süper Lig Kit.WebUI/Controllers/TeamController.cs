using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;

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
            var client= _client.CreateClient();
             var response=await client.GetFromJsonAsync<List<Team>>("https://localhost:7245/api/teams");

            return View(response);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTeamDto team)
        {
            
                var client= _client.CreateClient();
                var response=await client.PostAsJsonAsync("https://localhost:7245/api/teams",team);

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
