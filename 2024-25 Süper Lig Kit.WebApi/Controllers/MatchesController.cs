using _2024_25_Süper_Lig_Kit.Dto.MatchDtos;
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
    public class MatchesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MatchesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatches(int week)
        {
            var matches =await _context.Matches.Include(x=>x.HomeTeam).Include(y=>y.AwayTeam ).Include(z=>z.Referee)
                .Include(w=>w.HomeTeamJerseyImageGK)
                .Include(w=>w.HomeTeamJerseyImage)
                .Include(w=>w.RefereeJerseyImage)
                .Include(w=>w.AwayTeamJerseyImageGK)
                .Include(w=>w.AwayTeamJerseyImage)
                .Where(x=>x.Week==week)
                .ToListAsync();
            return Ok(matches);
        }

        [HttpGet("GetMatchesByTeam")]
        public async Task<IActionResult> GetMatchesByTeam(int teamId)
        {
            var matches =await _context.Matches.Include(x=>x.HomeTeam).Include(y=>y.AwayTeam ).Include(z=>z.Referee)
                .Include(w=>w.HomeTeamJerseyImageGK)
                .Include(w=>w.HomeTeamJerseyImage)
                .Include(w=>w.RefereeJerseyImage)
                .Include(w=>w.AwayTeamJerseyImageGK)
                .Include(w=>w.AwayTeamJerseyImage)
                .Where(x => x.HomeTeamId == teamId || x.AwayTeamId == teamId).OrderBy(x=>x.Week).ToListAsync();
            return Ok(matches);
        }
        [HttpGet("GetMatchesByReferee")]
        public async Task<IActionResult> GetMatchesByReferee(int refereeId)
        {
            var matches = await _context.Matches.Include(x => x.HomeTeam).Include(y => y.AwayTeam).Include(z => z.Referee)
                .Include(w => w.HomeTeamJerseyImageGK)
                .Include(w => w.HomeTeamJerseyImage)
                .Include(w => w.RefereeJerseyImage)
                .Include(w => w.AwayTeamJerseyImageGK)
                .Include(w => w.AwayTeamJerseyImage)
                .Where(x => x.RefereeId==refereeId).OrderBy(x => x.Week).ToListAsync();
            return Ok(matches);
        }

        [HttpGet("CrossTable")]
        public async Task<IActionResult> CrossTable()
        {
            var crossTable = _context.Teams
    .Select(homeTeam => new
    {
        HomeTeam = homeTeam.Name,
        HomeTeamLogo= homeTeam.Logo,
        Kits = _context.Teams.Select(awayTeam => new
        {
            AwayTeam = awayTeam.Name,
            HomeKit = _context.Matches
                        .Where(m => m.HomeTeamId == homeTeam.TeamId && m.AwayTeamId == awayTeam.TeamId)
                        .Select(m => m.HomeTeamJerseyImage)
                        .FirstOrDefault(),
            AwayKit = _context.Matches
                        .Where(m => m.HomeTeamId == homeTeam.TeamId && m.AwayTeamId == awayTeam.TeamId)
                        .Select(m => m.AwayTeamJerseyImage)
                        .FirstOrDefault()
        }).ToList()
    })
    .ToList();
            return Ok(crossTable);
        }


        [HttpPost]
        public IActionResult CreateMatch(CreateMatchDtoForPost createMatchDto)
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
