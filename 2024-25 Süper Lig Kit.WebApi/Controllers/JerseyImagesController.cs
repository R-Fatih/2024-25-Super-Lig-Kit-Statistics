using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JerseyImagesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JerseyImagesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetJerseyImages()
        {
            var Jerseys = _context.JerseyImages.ToList();
            return Ok(Jerseys);
        }
        [HttpPost]
        public IActionResult CreateJersey(CreateJerseyImageDto Jersey)
        {
            _context.JerseyImages.Add(new JerseyImage
            {
                JerseyId = Jersey.JerseyId,
                ImgPath = Jersey.ImgPath


            });
            _context.SaveChanges();
            return Created("", Jersey);
        }
    }
}
