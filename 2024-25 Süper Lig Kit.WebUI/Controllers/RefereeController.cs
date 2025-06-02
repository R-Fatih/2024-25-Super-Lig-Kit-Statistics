using _2024_25_Süper_Lig_Kit.Dto.RefereeDtos;
using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class RefereeController : Controller
    {
        private readonly IHttpClientFactory _client;

        public RefereeController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var client= _client.CreateClient("Default");
            var response=await client.GetFromJsonAsync<List<ResultRefereeDto>>("/api/Referees");

            return View(response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRefereeDto referee)
        {
            
                var client= _client.CreateClient("Default");
                var response=await client.PostAsJsonAsync("/api/Referees",referee);

                // Takım oluşturma işlemi
                return RedirectToAction("Index");
            
            return View(referee);
        }

    }
}
