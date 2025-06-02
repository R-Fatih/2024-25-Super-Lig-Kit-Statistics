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
            var client= _client.CreateClient("Default");
             var response=await client.GetFromJsonAsync<List<Jersey>>("/api/Jerseys");

            return View(response);
        }
        [Route("Jersey/Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _client.CreateClient("Default");
            var response = await client.GetFromJsonAsync<List<Jersey>>($"/api/Jerseys/GetAllJerseysByTeam?teamId={id}");

            return View(response);
        }



        public async Task<IActionResult> Images(int id)
        {
            var client = _client.CreateClient("Default");
            var response = await client.GetFromJsonAsync<List<JerseyImage>>($"/api/Teams/GetKitImagesByKit?kitid={id}");
            ViewBag.id= id; 
            return View(response);
        }
        [Route("Jersey/Images/Create/{id}")]
        public async Task<IActionResult> CreateJ(int id)
        {
            var client = _client.CreateClient("Default");

            return View();
        }
        [Route("Jersey/Images/Create/{id}")]

        [HttpPost]
        public async Task<IActionResult> CreateJ(CreateJerseyImageDto Jersey,int id)
        {
            Jersey.JerseyId=id;
            var client = _client.CreateClient("Default");
            var response = await client.PostAsJsonAsync("/api/JerseyImages", Jersey);

            // Takım oluşturma işlemi
            return RedirectToAction("Index");

            return View(Jersey);
        }


        public async Task<IActionResult> Create()
        {
            var client = _client.CreateClient("Default");
            ViewBag.Teams = new SelectList(await client.GetFromJsonAsync<List<Team>>("/api/Teams"), "TeamId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateJerseyDto Jersey)
        {
            
                var client= _client.CreateClient("Default");
                var response=await client.PostAsJsonAsync("/api/Jerseys",Jersey);

            // Takım oluşturma işlemi
            return RedirectToAction("Index");
            
            return View(Jersey);
        }

        // Update action
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = _client.CreateClient("Default");
            var response = await client.GetFromJsonAsync<UpdateJerseyDto>($"/api/Jerseys/{id}");


            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateJerseyDto Jersey)
        {
            
            var client = _client.CreateClient("Default");
            var response =await client.PutAsJsonAsync("/api/Jerseys", Jersey);
                // Takım güncelleme işlemi
                return RedirectToAction("Index");
            
            return View(Jersey);
        }
    
}
}
