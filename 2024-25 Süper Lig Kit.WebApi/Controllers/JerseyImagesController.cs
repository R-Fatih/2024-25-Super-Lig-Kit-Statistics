using _2024_25_Süper_Lig_Kit.Dto.JerseyDtos;
using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var Jerseys = _context.JerseyImages.Include(x=>x.HomeTeamJerseyImageGKMatches).Include(y=>y.HomeTeamJerseyImageMatches).Include(z=>z.RefereeJerseyImageMatches).Include(w=>w.AwayTeamJerseyImageGKMatches).Include(u=>u.AwayTeamJerseyImageMatches).Select(t=>new JerseyImage
            {
                JerseyId = t.JerseyId,
                ImgPath = t.ImgPath,
                JerseyImageId = t.JerseyImageId,
                AwayTeamJerseyImageGKMatches = t.AwayTeamJerseyImageGKMatches.Select(x => new Match
                {
                    AwayMS = x.AwayMS,
                    HomeMS = x.HomeMS,
                    Date = x.Date,
                    MatchId = x.MatchId,
                    HomeTeamId = x.HomeTeamId,
                    AwayTeamId = x.AwayTeamId,
                    RefereeId = x.RefereeId,
                    Week = x.Week,
                    MainId = x.MainId,
                    Maçkolik = x.Maçkolik,
                }).ToList(),
                AwayTeamJerseyImageMatches = t.AwayTeamJerseyImageMatches.Select(x => new Match
                {
                    AwayMS = x.AwayMS,
                    HomeMS = x.HomeMS,
                    Date = x.Date,
                    MatchId = x.MatchId,
                    HomeTeamId = x.HomeTeamId,
                    AwayTeamId = x.AwayTeamId,
                    RefereeId = x.RefereeId,
                    Week = x.Week,
                    MainId = x.MainId,
                    Maçkolik = x.Maçkolik,
                }).ToList(),
                HomeTeamJerseyImageGKMatches = t.HomeTeamJerseyImageGKMatches.Select(x => new Match
                {
                    AwayMS = x.AwayMS,
                    HomeMS = x.HomeMS,
                    Date = x.Date,
                    MatchId = x.MatchId,
                    HomeTeamId = x.HomeTeamId,
                    AwayTeamId = x.AwayTeamId,
                    RefereeId = x.RefereeId,
                    Week = x.Week,
                    MainId = x.MainId,
                    Maçkolik = x.Maçkolik,
                }).ToList(),
                HomeTeamJerseyImageMatches = t.HomeTeamJerseyImageMatches.Select(x => new Match
                {
                    AwayMS = x.AwayMS,
                    HomeMS = x.HomeMS,
                    Date = x.Date,
                    MatchId = x.MatchId,
                    HomeTeamId = x.HomeTeamId,
                    AwayTeamId = x.AwayTeamId,
                    RefereeId = x.RefereeId,
                    Week = x.Week,
                    MainId = x.MainId,
                    Maçkolik = x.Maçkolik,
                }).ToList(),
                RefereeJerseyImageMatches = t.RefereeJerseyImageMatches.Select(x => new Match
                {
                    AwayMS = x.AwayMS,
                    HomeMS = x.HomeMS,
                    Date = x.Date,
                    MatchId = x.MatchId,
                    HomeTeamId = x.HomeTeamId,
                    AwayTeamId = x.AwayTeamId,
                    RefereeId = x.RefereeId,
                    Week = x.Week,
                    MainId = x.MainId,
                    Maçkolik = x.Maçkolik,

                }).ToList()
            });
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
