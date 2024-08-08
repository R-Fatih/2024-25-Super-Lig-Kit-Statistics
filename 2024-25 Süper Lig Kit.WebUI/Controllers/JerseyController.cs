using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.WebUI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class JerseyController : Controller
    {
        private readonly IHttpClientFactory _client;

        public JerseyController(IHttpClientFactory client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            var client= _client.CreateClient();
             var response=await client.GetFromJsonAsync<List<Jersey>>("https://localhost:7245/api/Jerseys");

            return View(response);
        }
        public async Task<IActionResult> Images(int id)
        {
            var client = _client.CreateClient();
            var response = await client.GetFromJsonAsync<List<JerseyImage>>($"https://localhost:7245/api/Teams/GetKitImagesByKit?kitid={id}");
            ViewBag.id= id; 
            return View(response);
        }
        [Route("Jersey/Images/Create/{id}")]
        public async Task<IActionResult> CreateJ(int id)
        {
            var client = _client.CreateClient();

            return View();
        }
        [Route("Jersey/Images/Create/{id}")]

        [HttpPost]
        public async Task<IActionResult> CreateJ(CreateJerseyImageDto Jersey,int id)
        {
            Jersey.JerseyId=id;
            var client = _client.CreateClient();
            var response = await client.PostAsJsonAsync("https://localhost:7245/api/JerseyImages", Jersey);

            // Takım oluşturma işlemi
            return RedirectToAction("Index");

            return View(Jersey);
        }


        public async Task<IActionResult> Create()
        {
            var client = _client.CreateClient();
            ViewBag.Teams = new SelectList(await client.GetFromJsonAsync<List<Team>>("https://localhost:7245/api/Teams"), "TeamId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJerseyDto Jersey)
        {
            
                var client= _client.CreateClient();
                var response=await client.PostAsJsonAsync("https://localhost:7245/api/Jerseys",Jersey);

            // Takım oluşturma işlemi
            return RedirectToAction("Index");
            
            return View(Jersey);
        }

        // Update action
        public IActionResult Update(int id)
        {
            // Güncellenecek takımı bul
            var Jersey = new Jersey(); // Bu örnekte boş bir takım nesnesi kullanıyoruz
            return View(Jersey);
        }

        [HttpPost]
        public IActionResult Update(Jersey Jersey)
        {
            if (ModelState.IsValid)
            {
                // Takım güncelleme işlemi
                return RedirectToAction("Index");
            }
            return View(Jersey);
        }
    
}
}
