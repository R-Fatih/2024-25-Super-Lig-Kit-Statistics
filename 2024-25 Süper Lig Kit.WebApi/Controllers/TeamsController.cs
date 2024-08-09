using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeamsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetTeams()
        {
            var teams = _context.Teams.ToList();
            return Ok(teams);
        }
        [HttpGet("{id}")]
        public IActionResult GetTeam(int id)
        {
            var team = _context.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }
            return Ok(team);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDto team)
        {
            _context.Teams.Add(new Team
            {
                Name = team.Name,
                Logo = team.Logo
            });
            _context.SaveChanges();
            return Created("", team);
        }
        [HttpPut]
        public IActionResult UpdateTeam(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpGet("GetKitsByTeam")]
        public IActionResult GetKitsByTeam(int teamId)
        {
            var kits = _context.Jerseys.Include(x=>x.JerseyImages).Where(x => x.TeamId == teamId && x.IsKeeper == false).Select(x=>new ResultJerseyDto
            {

                Body = x.Body,
                Id = x.Id,
                Name = x.Name,
                Shorts = x.Shorts,
                Socks = x.Socks,
                TeamId = x.TeamId,
                JerseyImages = x.JerseyImages.Select(x => new ResultJerseyImageDto
                {
                    JerseyImageId = x.JerseyImageId,
                    JerseyId = x.JerseyId,
                    ImgPath = x.ImgPath
                }).ToList()
            }).ToList();
            return Ok(kits);
        }
        [HttpGet("GetKitImagesByKit")]
        public IActionResult GetKitImagesByKit(int kitid)
        {
            var kits = _context.JerseyImages.Where(x => x.JerseyId == kitid).ToList();
            return Ok(kits);
        }
        [HttpGet("GetKeeperJerseysByTeam")]
        public IActionResult GetKeeperJerseysByTeam(int teamId)
        {
            var Jerseys = _context.Jerseys.Where(x => x.TeamId == teamId && x.IsKeeper == true).ToList();
            return Ok(Jerseys);
        }
    }
}
