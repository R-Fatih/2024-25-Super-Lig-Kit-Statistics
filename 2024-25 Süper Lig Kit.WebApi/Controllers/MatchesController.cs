using _2024_25_Süper_Lig_Kit.Dto.MatchDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatchesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateMatch(CreateMatchDto createMatchDto)
        {

            _context.Matches.Add(new Match
            {
                AwayMS = createMatchDto.AwayMS,
                AwayTeamId = createMatchDto.AwayTeamId,
                AwayTeamJerseyImageGKId = createMatchDto.AwayTeamJerseyImageGKId,
                AwayTeamJerseyImageId = createMatchDto.AwayTeamJerseyImageId,
                Date = createMatchDto.Date,
                HomeMS = createMatchDto.HomeMS,
                HomeTeamId = createMatchDto.HomeTeamId,
                HomeTeamJerseyImageGKId = createMatchDto.HomeTeamJerseyImageGKId,
                HomeTeamJerseyImageId = createMatchDto.HomeTeamJerseyImageId,
                MainId = createMatchDto.MainId,
                Maçkolik = createMatchDto.Maçkolik,
                RefereeId = createMatchDto.RefereeId,
                RefereeJerseyImageId = createMatchDto.RefereeJerseyImageId,
                Week = createMatchDto.Week,


            });
            _context.SaveChanges();
            return Created("", createMatchDto);
        }
    }
}
