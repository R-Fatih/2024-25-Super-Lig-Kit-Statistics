using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JerseysController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JerseysController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetJerseys()
        {
            var Jerseys = _context.Jerseys.ToList();
            return Ok(Jerseys);
        }
        [HttpGet("{id}")]
        public IActionResult GetJersey(int id)
        {
            var Jersey = _context.Jerseys.Find(id);
            if (Jersey == null)
            {
                return NotFound();
            }
            return Ok(Jersey);
        }


        [HttpPost]
        public IActionResult CreateJersey(CreateJerseyDto Jersey)
        {
            _context.Jerseys.Add(new Jersey
            {
                Name = Jersey.Name,
                IsKeeper=Jersey.IsKeeper,
                TeamId=Jersey.TeamId
            
                
            });
            _context.SaveChanges();
            return Created("", Jersey);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateJersey(UpdateJerseyDto Jersey)
        {
            var jersey = await _context.Jerseys.FindAsync(Jersey.Id);
            
            jersey.Name = Jersey.Name;
           
            jersey.TeamId = Jersey.TeamId;
            jersey.IsKeeper = Jersey.IsKeeper;
            
            _context.Jerseys.Update(jersey);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteJersey(int id)
        {
            var Jersey = _context.Jerseys.Find(id);
            _context.Jerseys.Remove(Jersey);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("GetJerseysByTeam")]
        public IActionResult GetJerseysByTeam(int teamId)
        {
            var Jerseys = _context.Jerseys.Where(x => x.TeamId == teamId&&x.IsKeeper==false).ToList();
            return Ok(Jerseys);
        }
        [HttpGet("GetAllJerseysByTeam")]
        public IActionResult GetAllJerseysByTeam(int teamId)
        {
            var Jerseys = _context.Jerseys.Where(x => x.TeamId == teamId ).ToList();
            return Ok(Jerseys);
        }
    }
}
