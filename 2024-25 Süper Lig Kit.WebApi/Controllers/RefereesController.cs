using _2024_25_Süper_Lig_Kit.Dto.RefereeDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefereesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RefereesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetReferees()
        {
            var Referees =await _context.Referees.ToListAsync();
            return Ok(Referees);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReferee(CreateRefereeDto Referee)
        {
            _context.Referees.Add(new Referee
            {
                RefereeName = Referee.RefereeName,
                IsFifa = Referee.IsFifa,
                ImgUrl = Referee.ImgUrl
            });
            await _context.SaveChangesAsync();
            return Created("", Referee);
        }
    }
}
