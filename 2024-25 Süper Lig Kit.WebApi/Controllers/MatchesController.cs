using _2024_25_Süper_Lig_Kit.Dto.MatchDtos;
using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using _2024_25_Süper_Lig_Kit.WebApi.Context;
using _2024_25_Süper_Lig_Kit.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        [HttpGet("GetAllTeamsKitsWeeks")]
        public async Task<IActionResult> GetAllTeamsKitsWeeks()
        {

            // Önce sistemdeki tüm haftaları bulalım
            // Önce tüm haftaları alalım
            var allWeeks = _context.Matches.Select(m => m.Week).Distinct().OrderBy(w => w).ToList();

            // Önce takım ve maç bilgilerini alalım
            var matchData = _context.Teams.Select(team => new
            {
                newTeam = team.Name,
                HomeTeamLogo = team.Logo,
                TeamId = team.TeamId,
                Matches = _context.Matches
                    .Where(x => x.HomeTeamId == team.TeamId || x.AwayTeamId == team.TeamId)
                    .Select(match => new
                    {
                        Week = match.Week,
                        Kit = match.HomeTeamId == team.TeamId ? match.HomeTeamJerseyImage : match.AwayTeamJerseyImage,
                    })
                    .ToList()
            }).ToList();

            // Sonra in-memory'de birleştirme yapalım
            var table = matchData.Select(team => new
            {
                newTeam = team.newTeam,
                HomeTeamLogo = team.HomeTeamLogo,
                Kits = allWeeks.Select(week => new
                {
                    Week = week,
                    Kit = team.Matches.FirstOrDefault(m => m.Week == week)?.Kit,
                    IsBye = !team.Matches.Any(m => m.Week == week)
                })
                .OrderBy(k => k.Week)
                .ToList()
            }).ToList();

            return Ok(table);
        }

        [HttpGet("GetAllTeamsKitsWeeksGK")]
        public async Task<IActionResult> GetAllTeamsKitsWeeksGK()
        {

            // Önce sistemdeki tüm haftaları bulalım
            // Önce tüm haftaları alalım
            var allWeeks = _context.Matches.Select(m => m.Week).Distinct().OrderBy(w => w).ToList();

            // Önce takım ve maç bilgilerini alalım
            var matchData = _context.Teams.Select(team => new
            {
                newTeam = team.Name,
                HomeTeamLogo = team.Logo,
                TeamId = team.TeamId,
                Matches = _context.Matches
                    .Where(x => x.HomeTeamId == team.TeamId || x.AwayTeamId == team.TeamId)
                    .Select(match => new
                    {
                        Week = match.Week,
                        Kit = match.HomeTeamId == team.TeamId ? match.HomeTeamJerseyImageGK : match.AwayTeamJerseyImageGK,
                    })
                    .ToList()
            }).ToList();

            // Sonra in-memory'de birleştirme yapalım
            var table = matchData.Select(team => new
            {
                newTeam = team.newTeam,
                HomeTeamLogo = team.HomeTeamLogo,
                Kits = allWeeks.Select(week => new
                {
                    Week = week,
                    Kit = team.Matches.FirstOrDefault(m => m.Week == week)?.Kit,
                    IsBye = !team.Matches.Any(m => m.Week == week)
                })
                .OrderBy(k => k.Week)
                .ToList()
            }).ToList();

            return Ok(table);
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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMatchDto dto)
        {
            var match = await _context.Matches.FirstOrDefaultAsync(x => x.MatchId == dto.MatchId);
            if(match==null)
                return NotFound();

            var client = new HttpClient();
            var responseMessage = await client.GetAsync($"https://localhost:7245/api/Mackoliks/get?adres={dto.Maçkolik}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMatchDto>(jsonData);

                match.Date = values.Date;
                match.HomeMS = values.HomeMS;
                match.AwayMS = values.AwayMS;
                match.Maçkolik = dto.Maçkolik;

            }
             _context.Update(match);
            await _context.SaveChangesAsync();
            return Ok();


        }

        [HttpGet("RemainingMatches")]
        public async Task<IActionResult> RemainingMatches()
        {
            var remain=await _context.Matches.Where(x => x.Maçkolik==null).ToListAsync();
            return Ok(remain);
        }
    }
}
