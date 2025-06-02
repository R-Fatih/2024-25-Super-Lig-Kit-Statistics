using _2024_25_Süper_Lig_Kit.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Süper_Lig_Forma_İstatistikleri.Api.Model;

namespace _2024_25_Süper_Lig_Kit.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StaticsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetMostWearedKits")]
        public async Task<IActionResult> GetMostWearedKits()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT T.Name as 'TeamName', J.Name as 'Body', COUNT(*) AS KitCount, J.Path FROM ( SELECT HomeTeamId, HomeTeamJerseyImageId FROM Matches UNION ALL SELECT AwayTeamId, AwayTeamJerseyImageId FROM Matches ) AS combined_matches INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsCombines")]
        public async Task<IActionResult> GetMostWearedKitsCombines()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT T.Name as TeamName, J.Name as 'Body', Count(*) as 'KitCount', J.Path as 'Path' FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageId FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsGK")]
        public async Task<IActionResult> GetMostWearedKitsGK()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT T.Name as 'TeamName', J.Name as 'Name', COUNT(*) AS KitCount, J.Path FROM ( SELECT HomeTeamId, HomeTeamJerseyImageGKId FROM Matches UNION ALL SELECT AwayTeamId, AwayTeamJerseyImageGKId FROM Matches ) AS combined_matches INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId INNER JOIN Jerseys J ON JI.JerseyId = J.Id INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsInHome")]
        public async Task<IActionResult> GetMostWearedKitsInHome()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT T.Name as TeamName, J.Name as Body, Count(*) as 'KitCount', J.Path FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId  FROM Matches   ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsInAway")]
        public async Task<IActionResult> GetMostWearedKitsInAway()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModel>("SELECT T.Name as TeamName, J.Name as Body, Count(*) as 'KitCount', J.Path FROM (   SELECT AwayTeamId,AwayTeamJerseyImageId  FROM Matches   ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.AwayTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.AwayTeamId   GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsInHomeGK")]
        public async Task<IActionResult> GetMostWearedKitsInHomeGK()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT T.Name as TeamName, J.Name, Count(*) as 'KitCount', J.Path FROM (   SELECT HomeTeamId,HomeTeamJerseyImageGKId  FROM Matches   ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsInAwayGK")]
        public async Task<IActionResult> GetMostWearedKitsInAwayGK()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelGK>("SELECT T.Name as TeamName, J.Name, Count(*) as 'KitCount', J.Path FROM (   SELECT AwayTeamId,AwayTeamJerseyImageGKId  FROM Matches   ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.AwayTeamJerseyImageGKId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.AwayTeamId   GROUP BY T.Name, J.Name, J.Path ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsReferee")]
        public async Task<IActionResult> GetMostWearedKitsReferee()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT J.Name as Body, Count(*) as 'KitCount' FROM Matches M INNER JOIN JerseyImages JI ON M.RefereeJerseyImageId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id GROUP BY J.Name ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedKitsRefereeCombines")]
        public async Task<IActionResult> GetMostWearedKitsRefereeCombines()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT JI.ImgPath as 'Body', Count(*) as 'KitCount' FROM Matches M INNER JOIN JerseyImages JI ON M.RefereeJerseyImageId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id GROUP BY JI.ImgPath ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetUnwearedKits")]
        public async Task<IActionResult> GetUnwearedKits()
        {
            var values = _context.Database.SqlQueryRaw<UnwearedKitsModel>("SELECT J.TeamId, J.Name as Body, T.Name as TeamName FROM Jerseys J INNER JOIN Teams T ON T.TeamId = J.TeamId WHERE J.IsKeeper = 0 AND J.TeamId != 21 EXCEPT (SELECT M.HomeTeamId, J.Name as Body, T.Name as TeamName FROM Matches M INNER JOIN Teams T ON T.TeamId = M.HomeTeamId INNER JOIN JerseyImages JI ON M.HomeTeamJerseyImageId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id UNION ALL SELECT M.AwayTeamId, J.Name as Body, T.Name as TeamName FROM Matches M INNER JOIN Teams T ON T.TeamId = M.AwayTeamId INNER JOIN JerseyImages JI ON M.AwayTeamJerseyImageId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id)").ToList();
            return Ok(values);
        }
        [HttpGet("GetUnwearedKitsGK")]
        public async Task<IActionResult> GetUnwearedKitsGK()
        {
            var values = _context.Database.SqlQueryRaw<UnwearedKitsModel>("SELECT J.TeamId, J.Name as Body, T.Name as TeamName FROM Jerseys J INNER JOIN Teams T ON T.TeamId = J.TeamId WHERE J.IsKeeper = 1 AND J.TeamId != 21 EXCEPT (SELECT M.HomeTeamId, J.Name as Body, T.Name as TeamName FROM Matches M INNER JOIN Teams T ON T.TeamId = M.HomeTeamId INNER JOIN JerseyImages JI ON M.HomeTeamJerseyImageGKId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id UNION ALL SELECT M.AwayTeamId, J.Name as Body, T.Name as TeamName FROM Matches M INNER JOIN Teams T ON T.TeamId = M.AwayTeamId INNER JOIN JerseyImages JI ON M.AwayTeamJerseyImageGKId = JI.JerseyImageId INNER JOIN Jerseys J ON JI.JerseyId = J.Id)").ToList();
            return Ok(values);
        }
        [HttpGet("GetKitBodyType")]
        public async Task<IActionResult> GetKitBodyType()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT J.Name as Body, Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageId FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY J.Name ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetKitBodyTypeGK")]
        public async Task<IActionResult> GetKitBodyTypeGK()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelReferee>("SELECT J.Name as Body, Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyImageGKId  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageGKId FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY J.Name ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetMostWearedCouples")]
        public async Task<IActionResult> GetMostWearedCouples()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelCouples>("SELECT T.Name as TeamName, J.Name as Body, JGK.Name as 'GKBody', Count(*) as 'KitCount' FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId,HomeTeamJerseyImageGKId  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageId,AwayTeamJerseyImageGKId FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN JerseyImages JIGK ON JIGK.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId INNER JOIN Jerseys JGK ON JGK.Id = JIGK.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, JGK.Name ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("Get100PercentHomeKitInHome")]
        public async Task<IActionResult> Get100PercentHomeKitInHome()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModel100Percent>("SELECT T.TeamId,T.Name as TeamName, J.Name as Body, Count(*) AS 'KitCount', ( SELECT COUNT(*) FROM Matches WHERE HomeTeamId = T.TeamId ) AS 'MatchCount', J.Path FROM ( SELECT HomeTeamId, HomeTeamJerseyImageId FROM Matches ) AS combined_matches INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId GROUP BY T.TeamId, T.Name, J.Name, J.Path HAVING count(*) = ( SELECT COUNT(*) FROM Matches WHERE HomeTeamId = T.TeamId ) ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetUnWinnedKits")]
        public async Task<IActionResult> GetUnWinnedKits()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelWithWDL>("SELECT T.Name as TeamName, J.Name as Body, Count(*) as 'KitCount', SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END) AS Wins, SUM(CASE WHEN HomeMS = AwayMS THEN 1 ELSE 0 END) AS Draws, SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END) AS Loses, Convert(decimal(4,2), SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END))/count(*)*100 as 'WinPercantage', Convert(decimal(4,2), SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END))/count(*)*100 as 'LosePercantage', J.Path  FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId,HomeMS,AwayMS  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageId, AwayMS, HomeMS FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, J.Path HAVING SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END) = 0 ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }
        [HttpGet("GetUndefeatedKits")]
        public async Task<IActionResult> GetUndefeatedKits()
        {
            var values = _context.Database.SqlQueryRaw<WearedKitsModelWithWDL>("SELECT T.Name as TeamName, J.Name as Body, Count(*) as 'KitCount', SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END) AS Wins, SUM(CASE WHEN HomeMS = AwayMS THEN 1 ELSE 0 END) AS Draws, SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END) AS Loses, Convert(decimal(4,2), SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END))/count(*)*100 as 'WinPercantage', Convert(decimal(4,2), SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END))/count(*)*100 as 'LosePercantage', J.Path  FROM (   SELECT HomeTeamId,HomeTeamJerseyImageId,HomeMS,AwayMS  FROM Matches    UNION ALL   SELECT AwayTeamId,AwayTeamJerseyImageId, AwayMS, HomeMS FROM Matches ) AS combined_matches  INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId INNER JOIN Jerseys J ON J.Id = JI.JerseyId INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId   GROUP BY T.Name, J.Name, J.Path HAVING SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END) = 0 ORDER BY KitCount DESC").ToList();
            return Ok(values);
        }

        // === 1. Forma-Başarı Korelasyonu ===
        [HttpGet("GetKitSuccessCorrelation")]
        public async Task<IActionResult> GetKitSuccessCorrelation()
        {
            var values = _context.Database.SqlQueryRaw<KitSuccessCorrelationModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as Body,
                    COUNT(*) as TotalMatches,
                    SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END) AS Wins,
                    SUM(CASE WHEN HomeMS = AwayMS THEN 1 ELSE 0 END) AS Draws,
                    SUM(CASE WHEN HomeMS < AwayMS THEN 1 ELSE 0 END) AS Losses,
                    CAST(SUM(CASE WHEN HomeMS > AwayMS THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as WinPercentage,
                    CAST((SUM(CASE WHEN HomeMS > AwayMS THEN 3 WHEN HomeMS = AwayMS THEN 1 ELSE 0 END) * 1.0 / COUNT(*)) AS DECIMAL(5,2)) as PointsPerMatch,
                    SUM(HomeMS) as GoalsFor,
                    SUM(AwayMS) as GoalsAgainst,
                    SUM(HomeMS) - SUM(AwayMS) as GoalDifference
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageId, HomeMS, AwayMS FROM Matches
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageId, AwayMS, HomeMS FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                GROUP BY T.Name, J.Name
                ORDER BY WinPercentage DESC, PointsPerMatch DESC
            ").ToList();
            return Ok(values);
        }

        // === 2. İç Saha Avantajı & Forma ===
        [HttpGet("GetHomeAdvantageByKit")]
        public async Task<IActionResult> GetHomeAdvantageByKit()
        {
            var values = _context.Database.SqlQueryRaw<HomeAdvantageKitModel>(@"
                WITH HomeStats AS (
                    SELECT 
                        T.Name as TeamName,
                        J.Name as Body,
                        COUNT(*) as HomeMatches,
                        SUM(CASE WHEN M.HomeMS > M.AwayMS THEN 1 ELSE 0 END) AS HomeWins,
                        SUM(CASE WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END) AS HomeDraws,
                        SUM(CASE WHEN M.HomeMS < M.AwayMS THEN 1 ELSE 0 END) AS HomeLosses,
                        CAST(SUM(CASE WHEN M.HomeMS > M.AwayMS THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as HomeWinPercentage,
                        CAST((SUM(CASE WHEN M.HomeMS > M.AwayMS THEN 3 WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END) * 1.0 / COUNT(*)) AS DECIMAL(5,2)) as HomePointsPerMatch
                    FROM Matches M
                    INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.HomeTeamJerseyImageId
                    INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                    INNER JOIN Teams T ON T.TeamId = M.HomeTeamId
                    GROUP BY T.Name, J.Name
                ),
                AwayStats AS (
                    SELECT 
                        T.Name as TeamName,
                        J.Name as Body,
                        COUNT(*) as AwayMatches,
                        SUM(CASE WHEN M.AwayMS > M.HomeMS THEN 1 ELSE 0 END) AS AwayWins,
                        SUM(CASE WHEN M.AwayMS = M.HomeMS THEN 1 ELSE 0 END) AS AwayDraws,
                        SUM(CASE WHEN M.AwayMS < M.HomeMS THEN 1 ELSE 0 END) AS AwayLosses,
                        CAST(SUM(CASE WHEN M.AwayMS > M.HomeMS THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as AwayWinPercentage,
                        CAST((SUM(CASE WHEN M.AwayMS > M.HomeMS THEN 3 WHEN M.AwayMS = M.HomeMS THEN 1 ELSE 0 END) * 1.0 / COUNT(*)) AS DECIMAL(5,2)) as AwayPointsPerMatch
                    FROM Matches M
                    INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.AwayTeamJerseyImageId
                    INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                    INNER JOIN Teams T ON T.TeamId = M.AwayTeamId
                    GROUP BY T.Name, J.Name
                )
                SELECT 
                    COALESCE(H.TeamName, A.TeamName) as TeamName,
                    COALESCE(H.Body, A.Body) as Body,
                    COALESCE(H.HomeMatches, 0) as HomeMatches,
                    COALESCE(H.HomeWins, 0) as HomeWins,
                    COALESCE(H.HomeDraws, 0) as HomeDraws,
                    COALESCE(H.HomeLosses, 0) as HomeLosses,
                    COALESCE(H.HomeWinPercentage, 0) as HomeWinPercentage,
                    COALESCE(H.HomePointsPerMatch, 0) as HomePointsPerMatch,
                    COALESCE(A.AwayMatches, 0) as AwayMatches,
                    COALESCE(A.AwayWins, 0) as AwayWins,
                    COALESCE(A.AwayDraws, 0) as AwayDraws,
                    COALESCE(A.AwayLosses, 0) as AwayLosses,
                    COALESCE(A.AwayWinPercentage, 0) as AwayWinPercentage,
                    COALESCE(A.AwayPointsPerMatch, 0) as AwayPointsPerMatch,
                    COALESCE(H.HomeWinPercentage, 0) - COALESCE(A.AwayWinPercentage, 0) as HomeAdvantageIndex
                FROM HomeStats H
                FULL OUTER JOIN AwayStats A ON H.TeamName = A.TeamName AND H.Body = A.Body
                ORDER BY HomeAdvantageIndex DESC
            ").ToList();
            return Ok(values);
        }

        // === 3. Kaleci Forma Performansı ===
        [HttpGet("GetGoalkeeperKitPerformance")]
        public async Task<IActionResult> GetGoalkeeperKitPerformance()
        {
            var values = _context.Database.SqlQueryRaw<GoalkeeperKitPerformanceModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as Body,
                    COUNT(*) as MatchCount,
                    SUM(AwayMS) as GoalsConceded,
                    SUM(CASE WHEN AwayMS = 0 THEN 1 ELSE 0 END) as CleanSheets,
                    CAST(SUM(AwayMS) * 1.0 / COUNT(*) AS DECIMAL(5,2)) as GoalsPerMatch,
                    CAST(SUM(CASE WHEN AwayMS = 0 THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as CleanSheetPercentage,
                    CAST((COUNT(*) - SUM(AwayMS)) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as SaveEfficiency
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageGKId, HomeMS, AwayMS FROM Matches
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageGKId, AwayMS, HomeMS FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                WHERE J.IsKeeper = 1
                GROUP BY T.Name, J.Name
                ORDER BY CleanSheetPercentage DESC, GoalsPerMatch ASC
            ").ToList();
            return Ok(values);
        }

        // === 4. Haftalık Forma Dağılımı ===
        [HttpGet("GetWeeklyKitDistribution")]
        public async Task<IActionResult> GetWeeklyKitDistribution()
        {
            var values = _context.Database.SqlQueryRaw<WeeklyKitTrendModel>(@"
                SELECT 
                    M.Week,
                    T.Name as TeamName,
                    J.Name as Body,
                    COUNT(*) as KitUsageCount,
                    1 as IsHome,
                    MIN(M.Date) as MatchDate
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = M.HomeTeamId
                GROUP BY M.Week, T.Name, J.Name
                UNION ALL
                SELECT 
                    M.Week,
                    T.Name as TeamName,
                    J.Name as Body,
                    COUNT(*) as KitUsageCount,
                    0 as IsHome,
                    MIN(M.Date) as MatchDate
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.AwayTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = M.AwayTeamId
                GROUP BY M.Week, T.Name, J.Name
                ORDER BY Week, TeamName, Body
            ").ToList();
            return Ok(values);
        }

        // === 5. Sezon Sonu Analizi ===
        [HttpGet("GetSeasonEndKitAnalysis")]
        public async Task<IActionResult> GetSeasonEndKitAnalysis()
        {
            var values = _context.Database.SqlQueryRaw<WeeklyKitTrendModel>(@"
                SELECT 
                    M.Week,
                    T.Name as TeamName,
                    J.Name as Body,
                    COUNT(*) as KitUsageCount,
                    CASE WHEN M.HomeTeamId = T.TeamId THEN 1 ELSE 0 END as IsHome,
                    MIN(M.Date) as MatchDate
                FROM Matches M
                INNER JOIN JerseyImages JI ON (
                    (M.HomeTeamId = T.TeamId AND JI.JerseyImageId = M.HomeTeamJerseyImageId) OR
                    (M.AwayTeamId = T.TeamId AND JI.JerseyImageId = M.AwayTeamJerseyImageId)
                )
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON (T.TeamId = M.HomeTeamId OR T.TeamId = M.AwayTeamId)
                WHERE M.Week > 30
                GROUP BY M.Week, T.Name, J.Name, M.HomeTeamId, T.TeamId
                ORDER BY Week DESC, TeamName
            ").ToList();
            return Ok(values);
        }

        // === 6. Kritik Maçlarda Forma Tercihleri ===
        [HttpGet("GetCriticalMatchKitPreferences")]
        public async Task<IActionResult> GetCriticalMatchKitPreferences()
        {
            var values = _context.Database.SqlQueryRaw<CriticalMatchKitModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as Body,
                    SUM(HomeMS + AwayMS) as TotalScore,
                    COUNT(*) as MatchCount,
                    CAST(SUM(HomeMS + AwayMS) * 1.0 / COUNT(*) AS DECIMAL(5,2)) as AverageScore,
                    CASE WHEN SUM(HomeMS + AwayMS) / COUNT(*) > 3.5 THEN 1 ELSE 0 END as IsHighScoring,
                    AVG(CAST(M.Week AS DECIMAL)) as Week
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageId, HomeMS, AwayMS, Week FROM Matches
                    WHERE (HomeMS + AwayMS) >= 4
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageId, AwayMS, HomeMS, Week FROM Matches
                    WHERE (HomeMS + AwayMS) >= 4
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                GROUP BY T.Name, J.Name
                ORDER BY AverageScore DESC, MatchCount DESC
            ").ToList();
            return Ok(values);
        }

        // === 7. En Çok Forma Değiştiren Takımlar ===
        [HttpGet("GetMostKitChangingTeams")]
        public async Task<IActionResult> GetMostKitChangingTeams()
        {
            var values = _context.Database.SqlQueryRaw<TeamKitDiversityModel>(@"
                WITH TeamKitStats AS (
                    SELECT 
                        T.Name as TeamName,
                        COUNT(*) as TotalMatches,
                        COUNT(DISTINCT J.Id) as DifferentKitsUsed,
                        COUNT(DISTINCT JGK.Id) as DifferentGKKitsUsed
                    FROM (
                        SELECT HomeTeamId, HomeTeamJerseyImageId, HomeTeamJerseyImageGKId FROM Matches
                        UNION ALL
                        SELECT AwayTeamId, AwayTeamJerseyImageId, AwayTeamJerseyImageGKId FROM Matches
                    ) AS combined_matches
                    INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                    INNER JOIN JerseyImages JIGK ON JIGK.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId
                    INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                    INNER JOIN Jerseys JGK ON JIGK.JerseyId = JGK.Id
                    INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                    GROUP BY T.Name
                ),
                MostUsedKit AS (
                    SELECT 
                        T.Name as TeamName,
                        J.Name as MostUsedKit,
                        COUNT(*) as MostUsedKitCount,
                        ROW_NUMBER() OVER (PARTITION BY T.Name ORDER BY COUNT(*) DESC) as rn
                    FROM (
                        SELECT HomeTeamId, HomeTeamJerseyImageId FROM Matches
                        UNION ALL
                        SELECT AwayTeamId, AwayTeamJerseyImageId FROM Matches
                    ) AS combined_matches
                    INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                    INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                    INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                    GROUP BY T.Name, J.Name
                )
                SELECT 
                    TKS.TeamName,
                    TKS.TotalMatches,
                    TKS.DifferentKitsUsed,
                    TKS.DifferentGKKitsUsed,
                    CAST(TKS.DifferentKitsUsed * 1.0 / TKS.TotalMatches AS DECIMAL(5,2)) as KitChangeFrequency,
                    MUK.MostUsedKit,
                    MUK.MostUsedKitCount,
                    CAST(MUK.MostUsedKitCount * 100.0 / TKS.TotalMatches AS DECIMAL(5,2)) as KitLoyaltyPercentage
                FROM TeamKitStats TKS
                LEFT JOIN MostUsedKit MUK ON TKS.TeamName = MUK.TeamName AND MUK.rn = 1
                ORDER BY KitChangeFrequency DESC, DifferentKitsUsed DESC
            ").ToList();
            return Ok(values);
        }

        // === 8. Hakem Forma Tercihleri ===
        [HttpGet("GetRefereeKitPreferences")]
        public async Task<IActionResult> GetRefereeKitPreferences()
        {
            var values = _context.Database.SqlQueryRaw<RefereeAnalysisModel>(@"
                SELECT 
                    R.RefereeName,
                    J.Name as Body,
                    COUNT(*) as KitCount,
                    (SELECT COUNT(*) FROM Matches WHERE RefereeId = R.RefereeId) as TotalMatches,
                    CAST(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM Matches WHERE RefereeId = R.RefereeId) AS DECIMAL(5,2)) as KitUsagePercentage,
                    R.IsFifa
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.RefereeJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                GROUP BY R.RefereeName, J.Name, R.RefereeId, R.IsFifa
                ORDER BY R.RefereeName, KitCount DESC
            ").ToList();
            return Ok(values);
        }

        // === 9. Hakem-Takım Uyumu ===
        [HttpGet("GetRefereeTeamHarmony")]
        public async Task<IActionResult> GetRefereeTeamHarmony()
        {
            var values = _context.Database.SqlQueryRaw<RefereeTeamHarmonyModel>(@"
                SELECT 
                    R.RefereeName,
                    T.Name as TeamName,
                    JR.Name as RefereeKit,
                    JT.Name as TeamKit,
                    COUNT(*) as MatchCount,
                    CASE WHEN JR.Name = JT.Name THEN 1 ELSE 0 END as HasClash
                FROM Matches M
                INNER JOIN JerseyImages JIR ON JIR.JerseyImageId = M.RefereeJerseyImageId
                INNER JOIN Jerseys JR ON JIR.JerseyId = JR.Id
                INNER JOIN JerseyImages JIT ON JIT.JerseyImageId = M.HomeTeamJerseyImageId
                INNER JOIN Jerseys JT ON JIT.JerseyId = JT.Id
                INNER JOIN Teams T ON T.TeamId = M.HomeTeamId
                INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                GROUP BY R.RefereeName, T.Name, JR.Name, JT.Name
                ORDER BY MatchCount DESC, HasClash DESC
            ").ToList();
            return Ok(values);
        }

        // === 10. Forma Kullanım Heatmap Verisi ===
        [HttpGet("GetKitUsageHeatmapData")]
        public async Task<IActionResult> GetKitUsageHeatmapData()
        {
            var values = _context.Database.SqlQueryRaw<KitUsageHeatmapModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as Body,
                    J.Id as KitId,
                    COUNT(*) as UsageCount,
                    CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER (PARTITION BY T.Name) AS DECIMAL(5,2)) as UsagePercentage,
                    T.Logo as LogoUrl
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageId FROM Matches
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageId FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                GROUP BY T.Name, J.Name, J.Id, T.Logo
                ORDER BY T.Name, UsageCount DESC
            ").ToList();
            return Ok(values);
        }

        // === 10.1. Kaleci Forma Kullanım Heatmap Verisi ===
        [HttpGet("GetGoalkeeperKitUsageHeatmapData")]
        public async Task<IActionResult> GetGoalkeeperKitUsageHeatmapData()
        {
            var values = _context.Database.SqlQueryRaw<KitUsageHeatmapModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as Body,
                    J.Id as KitId,
                    COUNT(*) as UsageCount,
                    CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER (PARTITION BY T.Name) AS DECIMAL(5,2)) as UsagePercentage,
                    T.Logo as LogoUrl
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageGKId FROM Matches
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageGKId FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageGKId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = combined_matches.HomeTeamId
                WHERE J.IsKeeper = 1
                GROUP BY T.Name, J.Name, J.Id, T.Logo
                ORDER BY T.Name, UsageCount DESC
            ").ToList();
            return Ok(values);
        }

        // === 11. Skor Dağılımı ===
        [HttpGet("GetScoreDistributionByKit")]
        public async Task<IActionResult> GetScoreDistributionByKit()
        {
            var values = _context.Database.SqlQueryRaw<ScoreDistributionModel>(@"
                SELECT 
                    J.Name as Body,
                    HomeMS as HomeScore,
                    AwayMS as AwayScore,
                    COUNT(*) as MatchCount,
                    CAST(AVG(CAST(HomeMS AS DECIMAL)) AS DECIMAL(5,2)) as AverageGoalsFor,
                    CAST(AVG(CAST(AwayMS AS DECIMAL)) AS DECIMAL(5,2)) as AverageGoalsAgainst
                FROM (
                    SELECT HomeTeamId, HomeTeamJerseyImageId, HomeMS, AwayMS FROM Matches
                    UNION ALL
                    SELECT AwayTeamId, AwayTeamJerseyImageId, AwayMS, HomeMS FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                GROUP BY J.Name, HomeMS, AwayMS
                ORDER BY J.Name, HomeMS DESC, AwayMS DESC
            ").ToList();
            return Ok(values);
        }

        // === 12. Zaman Serisi Analizi ===
        [HttpGet("GetKitDiversityTimeSeries")]
        public async Task<IActionResult> GetKitDiversityTimeSeries()
        {
            var values = _context.Database.SqlQueryRaw<TimeSeriesModel>(@"
                SELECT 
                    Week,
                    MIN(Date) as Date,
                    COUNT(*) as TotalKitsUsed,
                    COUNT(DISTINCT J.Id) as DifferentKitsUsed,
                    CAST(COUNT(DISTINCT J.Id) * 1.0 / COUNT(*) AS DECIMAL(5,2)) as KitDiversityIndex
                FROM (
                    SELECT Week, Date, HomeTeamJerseyImageId FROM Matches
                    UNION ALL
                    SELECT Week, Date, AwayTeamJerseyImageId FROM Matches
                ) AS combined_matches
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = combined_matches.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                GROUP BY Week
                ORDER BY Week
            ").ToList();
            return Ok(values);
        }

        // === 13. Network Analizi Verisi ===
        [HttpGet("GetNetworkAnalysisData")]
        public async Task<IActionResult> GetNetworkAnalysisData()
        {
            var values = _context.Database.SqlQueryRaw<NetworkAnalysisModel>(@"
                SELECT 
                    T.Name as TeamName,
                    J.Name as KitName,
                    R.RefereeName,
                    COUNT(*) as ConnectionStrength,
                    'Team-Kit-Referee' as RelationType
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.HomeTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = M.HomeTeamId
                INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                GROUP BY T.Name, J.Name, R.RefereeName
                UNION ALL
                SELECT 
                    T.Name as TeamName,
                    J.Name as KitName,
                    R.RefereeName,
                    COUNT(*) as ConnectionStrength,
                    'Team-Kit-Referee' as RelationType
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.AwayTeamJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Teams T ON T.TeamId = M.AwayTeamId
                INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                GROUP BY T.Name, J.Name, R.RefereeName
                ORDER BY ConnectionStrength DESC
            ").ToList();
            return Ok(values);
        }

        // === Takım Sezon Özeti ===
        [HttpGet("GetTeamSeasonSummary/{teamId}")]
        public async Task<IActionResult> GetTeamSeasonSummary(int teamId)
        {
            try
            {
                // Sadece temel takım bilgilerini çek
                var teamBasicInfo = await _context.Database.SqlQueryRaw<TeamBasicInfo>(
                    @"SELECT 
                        T.TeamId,
                        T.Name as TeamName,
                        T.Logo as TeamLogo
                      FROM Teams T 
                      WHERE T.TeamId = {0}", teamId).FirstOrDefaultAsync();

                if (teamBasicInfo == null)
                {
                    return NotFound("Team not found");
                }

                // Oyuncu formaları
                var playerKits = await _context.Database.SqlQueryRaw<KitUsageSummary>(
                    @"SELECT 
                        J.Id as KitId,
                        J.Name as KitName,
                        J.Path as KitImagePath,
                        ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0) as TotalUsage,
                        ISNULL(HomeStats.HomeUsage, 0) as HomeUsage,
                        ISNULL(AwayStats.AwayUsage, 0) as AwayUsage,
                        ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0) as Wins,
                        ISNULL(HomeStats.HomeDraws, 0) + ISNULL(AwayStats.AwayDraws, 0) as Draws,
                        ISNULL(HomeStats.HomeLosses, 0) + ISNULL(AwayStats.AwayLosses, 0) as Losses,
                        CASE 
                            WHEN (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0 
                            THEN CAST((ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0)) * 100.0 / (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) AS DECIMAL(5,2))
                            ELSE 0 
                        END as WinPercentage,
                        ISNULL(HomeStats.HomeGoalsFor, 0) + ISNULL(AwayStats.AwayGoalsFor, 0) as GoalsFor,
                        ISNULL(HomeStats.HomeGoalsAgainst, 0) + ISNULL(AwayStats.AwayGoalsAgainst, 0) as GoalsAgainst,
                        CASE 
                            WHEN (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0 
                            THEN CAST(((ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0)) * 3 + (ISNULL(HomeStats.HomeDraws, 0) + ISNULL(AwayStats.AwayDraws, 0))) * 1.0 / (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) AS DECIMAL(5,2))
                            ELSE 0 
                        END as PointsPerMatch
                    FROM Jerseys J
                    LEFT JOIN (
                        SELECT 
                            J.Id as KitId,
                            COUNT(*) as HomeUsage,
                            SUM(CASE WHEN M.HomeMS > M.AwayMS THEN 1 ELSE 0 END) as HomeWins,
                            SUM(CASE WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END) as HomeDraws,
                            SUM(CASE WHEN M.HomeMS < M.AwayMS THEN 1 ELSE 0 END) as HomeLosses,
                            SUM(M.HomeMS) as HomeGoalsFor,
                            SUM(M.AwayMS) as HomeGoalsAgainst
                        FROM Matches M
                        INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.HomeTeamJerseyImageId
                        INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                        WHERE M.HomeTeamId = {0} AND J.IsKeeper = 0
                        GROUP BY J.Id
                    ) HomeStats ON J.Id = HomeStats.KitId
                    LEFT JOIN (
                        SELECT 
                            J.Id as KitId,
                            COUNT(*) as AwayUsage,
                            SUM(CASE WHEN M.AwayMS > M.HomeMS THEN 1 ELSE 0 END) as AwayWins,
                            SUM(CASE WHEN M.AwayMS = M.HomeMS THEN 1 ELSE 0 END) as AwayDraws,
                            SUM(CASE WHEN M.AwayMS < M.HomeMS THEN 1 ELSE 0 END) as AwayLosses,
                            SUM(M.AwayMS) as AwayGoalsFor,
                            SUM(M.HomeMS) as AwayGoalsAgainst
                        FROM Matches M
                        INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.AwayTeamJerseyImageId
                        INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                        WHERE M.AwayTeamId = {0} AND J.IsKeeper = 0
                        GROUP BY J.Id
                    ) AwayStats ON J.Id = AwayStats.KitId
                    WHERE J.TeamId = {0} AND J.IsKeeper = 0 
                      AND (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0
                    ORDER BY TotalUsage DESC", teamId).ToListAsync();

                // Kaleci formaları
                var goalkeeperKits = await _context.Database.SqlQueryRaw<KitUsageSummary>(
                    @"SELECT 
                        J.Id as KitId,
                        J.Name as KitName,
                        J.Path as KitImagePath,
                        ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0) as TotalUsage,
                        ISNULL(HomeStats.HomeUsage, 0) as HomeUsage,
                        ISNULL(AwayStats.AwayUsage, 0) as AwayUsage,
                        ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0) as Wins,
                        ISNULL(HomeStats.HomeDraws, 0) + ISNULL(AwayStats.AwayDraws, 0) as Draws,
                        ISNULL(HomeStats.HomeLosses, 0) + ISNULL(AwayStats.AwayLosses, 0) as Losses,
                        CASE 
                            WHEN (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0 
                            THEN CAST((ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0)) * 100.0 / (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) AS DECIMAL(5,2))
                            ELSE 0 
                        END as WinPercentage,
                        ISNULL(HomeStats.HomeGoalsFor, 0) + ISNULL(AwayStats.AwayGoalsFor, 0) as GoalsFor,
                        ISNULL(HomeStats.HomeGoalsAgainst, 0) + ISNULL(AwayStats.AwayGoalsAgainst, 0) as GoalsAgainst,
                        CASE 
                            WHEN (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0 
                            THEN CAST(((ISNULL(HomeStats.HomeWins, 0) + ISNULL(AwayStats.AwayWins, 0)) * 3 + (ISNULL(HomeStats.HomeDraws, 0) + ISNULL(AwayStats.AwayDraws, 0))) * 1.0 / (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) AS DECIMAL(5,2))
                            ELSE 0 
                        END as PointsPerMatch
                    FROM Jerseys J
                    LEFT JOIN (
                        SELECT 
                            J.Id as KitId,
                            COUNT(*) as HomeUsage,
                            SUM(CASE WHEN M.HomeMS > M.AwayMS THEN 1 ELSE 0 END) as HomeWins,
                            SUM(CASE WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END) as HomeDraws,
                            SUM(CASE WHEN M.HomeMS < M.AwayMS THEN 1 ELSE 0 END) as HomeLosses,
                            SUM(M.HomeMS) as HomeGoalsFor,
                            SUM(M.AwayMS) as HomeGoalsAgainst
                        FROM Matches M
                        INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.HomeTeamJerseyImageGKId
                        INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                        WHERE M.HomeTeamId = {0} AND J.IsKeeper = 1
                        GROUP BY J.Id
                    ) HomeStats ON J.Id = HomeStats.KitId
                    LEFT JOIN (
                        SELECT 
                            J.Id as KitId,
                            COUNT(*) as AwayUsage,
                            SUM(CASE WHEN M.AwayMS > M.HomeMS THEN 1 ELSE 0 END) as AwayWins,
                            SUM(CASE WHEN M.AwayMS = M.HomeMS THEN 1 ELSE 0 END) as AwayDraws,
                            SUM(CASE WHEN M.AwayMS < M.HomeMS THEN 1 ELSE 0 END) as AwayLosses,
                            SUM(M.AwayMS) as AwayGoalsFor,
                            SUM(M.HomeMS) as AwayGoalsAgainst
                        FROM Matches M
                        INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.AwayTeamJerseyImageGKId
                        INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                        WHERE M.AwayTeamId = {0} AND J.IsKeeper = 1
                        GROUP BY J.Id
                    ) AwayStats ON J.Id = AwayStats.KitId
                    WHERE J.TeamId = {0} AND J.IsKeeper = 1
                      AND (ISNULL(HomeStats.HomeUsage, 0) + ISNULL(AwayStats.AwayUsage, 0)) > 0
                    ORDER BY TotalUsage DESC", teamId).ToListAsync();

                // Rakip takım maçları
                var opponentMatchups = await _context.Database.SqlQueryRaw<OpponentMatchupModel>(
                    @"SELECT 
                        CASE WHEN M.HomeTeamId = {0} THEN M.AwayTeamId ELSE M.HomeTeamId END as OpponentId,
                        CASE WHEN M.HomeTeamId = {0} THEN AT.Name ELSE HT.Name END as OpponentName,
                        CASE WHEN M.HomeTeamId = {0} THEN AT.Logo ELSE HT.Logo END as OpponentLogo,
                        CASE WHEN M.HomeTeamId = {0} THEN HJ.Name ELSE '' END as HomeKitUsed,
                        CASE WHEN M.HomeTeamId = {0} THEN HJ.Path ELSE '' END as HomeKitImagePath,
                        CASE WHEN M.AwayTeamId = {0} THEN AJ.Name ELSE '' END as AwayKitUsed,
                        CASE WHEN M.AwayTeamId = {0} THEN AJ.Path ELSE '' END as AwayKitImagePath,
                        CASE WHEN M.HomeTeamId = {0} THEN HJGK.Name ELSE '' END as HomeGKKitUsed,
                        CASE WHEN M.HomeTeamId = {0} THEN HJGK.Path ELSE '' END as HomeGKKitImagePath,
                        CASE WHEN M.AwayTeamId = {0} THEN AJGK.Name ELSE '' END as AwayGKKitUsed,
                        CASE WHEN M.AwayTeamId = {0} THEN AJGK.Path ELSE '' END as AwayGKKitImagePath,
                        CASE WHEN M.HomeTeamId = {0} THEN 
                            CASE WHEN M.HomeMS > M.AwayMS THEN 1 ELSE 0 END
                        ELSE 0 END as HomeWins,
                        CASE WHEN M.HomeTeamId = {0} THEN 
                            CASE WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END
                        ELSE 0 END as HomeDraws,
                        CASE WHEN M.HomeTeamId = {0} THEN 
                            CASE WHEN M.HomeMS < M.AwayMS THEN 1 ELSE 0 END
                        ELSE 0 END as HomeLosses,
                        CASE WHEN M.AwayTeamId = {0} THEN 
                            CASE WHEN M.AwayMS > M.HomeMS THEN 1 ELSE 0 END
                        ELSE 0 END as AwayWins,
                        CASE WHEN M.AwayTeamId = {0} THEN 
                            CASE WHEN M.AwayMS = M.HomeMS THEN 1 ELSE 0 END
                        ELSE 0 END as AwayDraws,
                        CASE WHEN M.AwayTeamId = {0} THEN 
                            CASE WHEN M.AwayMS < M.HomeMS THEN 1 ELSE 0 END
                        ELSE 0 END as AwayLosses,
                        CASE WHEN M.HomeTeamId = {0} THEN CAST(M.HomeMS AS VARCHAR) + '-' + CAST(M.AwayMS AS VARCHAR)
                        ELSE CAST(M.AwayMS AS VARCHAR) + '-' + CAST(M.HomeMS AS VARCHAR) END as HomeScore,
                        CASE WHEN M.AwayTeamId = {0} THEN CAST(M.AwayMS AS VARCHAR) + '-' + CAST(M.HomeMS AS VARCHAR)
                        ELSE CAST(M.HomeMS AS VARCHAR) + '-' + CAST(M.AwayMS AS VARCHAR) END as AwayScore
                    FROM Matches M
                    INNER JOIN Teams HT ON HT.TeamId = M.HomeTeamId
                    INNER JOIN Teams AT ON AT.TeamId = M.AwayTeamId
                    INNER JOIN JerseyImages HJI ON HJI.JerseyImageId = M.HomeTeamJerseyImageId
                    INNER JOIN Jerseys HJ ON HJI.JerseyId = HJ.Id
                    INNER JOIN JerseyImages AJI ON AJI.JerseyImageId = M.AwayTeamJerseyImageId
                    INNER JOIN Jerseys AJ ON AJI.JerseyId = AJ.Id
                    INNER JOIN JerseyImages HJGKI ON HJGKI.JerseyImageId = M.HomeTeamJerseyImageGKId
                    INNER JOIN Jerseys HJGK ON HJGKI.JerseyId = HJGK.Id
                    INNER JOIN JerseyImages AJGKI ON AJGKI.JerseyImageId = M.AwayTeamJerseyImageGKId
                    INNER JOIN Jerseys AJGK ON AJGKI.JerseyId = AJGK.Id
                    WHERE M.HomeTeamId = {0} OR M.AwayTeamId = {0}
                    ORDER BY M.Week", teamId).ToListAsync();

                // Takım performans istatistikleri
                var performanceStats = await _context.Database.SqlQueryRaw<TeamPerformanceStats>(
                    @"SELECT 
                        COUNT(*) as TotalMatches,
                        SUM(CASE WHEN M.HomeTeamId = {0} THEN 1 ELSE 0 END) as HomeMatches,
                        SUM(CASE WHEN M.AwayTeamId = {0} THEN 1 ELSE 0 END) as AwayMatches,
                        SUM(CASE WHEN (M.HomeTeamId = {0} AND M.HomeMS > M.AwayMS) OR (M.AwayTeamId = {0} AND M.AwayMS > M.HomeMS) THEN 1 ELSE 0 END) as TotalWins,
                        SUM(CASE WHEN M.HomeMS = M.AwayMS THEN 1 ELSE 0 END) as TotalDraws,
                        SUM(CASE WHEN (M.HomeTeamId = {0} AND M.HomeMS < M.AwayMS) OR (M.AwayTeamId = {0} AND M.AwayMS < M.HomeMS) THEN 1 ELSE 0 END) as TotalLosses,
                        SUM(CASE WHEN M.HomeTeamId = {0} THEN M.HomeMS ELSE M.AwayMS END) as TotalGoalsFor,
                        SUM(CASE WHEN M.HomeTeamId = {0} THEN M.AwayMS ELSE M.HomeMS END) as TotalGoalsAgainst,
                        SUM(CASE WHEN (M.HomeTeamId = {0} AND M.HomeMS > M.AwayMS) OR (M.AwayTeamId = {0} AND M.AwayMS > M.HomeMS) THEN 3 
                                 WHEN M.HomeMS = M.AwayMS THEN 1 
                                 ELSE 0 END) as TotalPoints,
                        CAST(SUM(CASE WHEN (M.HomeTeamId = {0} AND M.HomeMS > M.AwayMS) OR (M.AwayTeamId = {0} AND M.AwayMS > M.HomeMS) THEN 1 ELSE 0 END) * 100.0 / COUNT(*) AS DECIMAL(5,2)) as WinPercentage,
                        CAST(SUM(CASE WHEN (M.HomeTeamId = {0} AND M.HomeMS > M.AwayMS) OR (M.AwayTeamId = {0} AND M.AwayMS > M.HomeMS) THEN 3 
                                     WHEN M.HomeMS = M.AwayMS THEN 1 
                                     ELSE 0 END) * 1.0 / COUNT(*) AS DECIMAL(5,2)) as PointsPerMatch,
                        (SELECT COUNT(DISTINCT J.Id) FROM Jerseys J 
                         INNER JOIN JerseyImages JI ON JI.JerseyId = J.Id
                         WHERE EXISTS (SELECT 1 FROM Matches M2 
                                      WHERE (M2.HomeTeamId = {0} AND M2.HomeTeamJerseyImageId = JI.JerseyImageId) 
                                         OR (M2.AwayTeamId = {0} AND M2.AwayTeamJerseyImageId = JI.JerseyImageId))
                         AND J.IsKeeper = 0 AND J.TeamId = {0}) as DifferentKitsUsed,
                        (SELECT COUNT(DISTINCT J.Id) FROM Jerseys J 
                         INNER JOIN JerseyImages JI ON JI.JerseyId = J.Id
                         WHERE EXISTS (SELECT 1 FROM Matches M2 
                                      WHERE (M2.HomeTeamId = {0} AND M2.HomeTeamJerseyImageGKId = JI.JerseyImageId) 
                                         OR (M2.AwayTeamId = {0} AND M2.AwayTeamJerseyImageGKId = JI.JerseyImageId))
                         AND J.IsKeeper = 1 AND J.TeamId = {0}) as DifferentGKKitsUsed
                    FROM Matches M
                    WHERE M.HomeTeamId = {0} OR M.AwayTeamId = {0}", teamId).FirstOrDefaultAsync();

                // Manuel olarak result nesnesini oluştur
                var result = new TeamSeasonSummaryModel
                {
                    TeamId = teamBasicInfo.TeamId,
                    TeamName = teamBasicInfo.TeamName,
                    TeamLogo = teamBasicInfo.TeamLogo,
                    PlayerKits = playerKits,
                    GoalkeeperKits = goalkeeperKits,
                    OpponentMatchups = opponentMatchups,
                    PerformanceStats = performanceStats
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllTeams")]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await _context.Database.SqlQueryRaw<TeamBasicInfo>(
                "SELECT TeamId, Name as TeamName, Logo as TeamLogo FROM Teams ORDER BY Name"
            ).ToListAsync();
            return Ok(teams);
        }

        // === Hakem Haftalık Forma Kullanımı ===
        [HttpGet("GetRefereeWeeklyKitUsage")]
        public async Task<IActionResult> GetRefereeWeeklyKitUsage()
        {
            var values = _context.Database.SqlQueryRaw<RefereeWeeklyKitModel>(@"
                SELECT 
                    R.RefereeId,
                    R.RefereeName,
                    R.ImgUrl,
                    M.Week,
                    M.MainId,
                    J.Name as KitName,
                    J.Path as KitImagePath,
                    JI.ImgPath as CombinedKitImagePath,
                    COUNT(*) as UsageCount
                FROM Matches M
                INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.RefereeJerseyImageId
                INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                GROUP BY R.RefereeId, R.RefereeName, R.ImgUrl, M.Week,M.MainId, J.Name, J.Path, JI.ImgPath
                ORDER BY R.RefereeName, M.Week
            ").ToList();
            return Ok(values);
        }

        // === En Çok Maç Yöneten Hakemler Detay ===
        [HttpGet("GetTopRefereesDetails")]
        public async Task<IActionResult> GetTopRefereesDetails()
        {
            try
            {
                // İlk olarak en çok maç yöneten 10 hakemi alalım
                var topReferees = await _context.Database.SqlQueryRaw<TopRefereeBasicModel>(@"
                    SELECT TOP 10 
                        R.RefereeId,
                        R.RefereeName,
                        R.ImgUrl,
                        CAST(COUNT(*) AS INT) as TotalMatches
                    FROM Matches M
                    INNER JOIN Referees R ON R.RefereeId = M.RefereeId
                    GROUP BY R.RefereeId, R.RefereeName, R.ImgUrl
                    ORDER BY COUNT(*) DESC
                ").ToListAsync();

                var result = new List<TopRefereeDetailsModel>();

                foreach (var referee in topReferees)
                {
                    // Her hakem için forma bilgilerini alalım
                    var kitData = await _context.Database.SqlQueryRaw<RefereeKitModel>(@"
                        SELECT 
                            J.Name as KitName,
                            J.Path as KitImagePath,
                            CAST(COUNT(*) AS INT) as KitUsageCount
                        FROM Matches M
                        INNER JOIN JerseyImages JI ON JI.JerseyImageId = M.RefereeJerseyImageId
                        INNER JOIN Jerseys J ON JI.JerseyId = J.Id
                        WHERE M.RefereeId = {0}
                        GROUP BY J.Name, J.Path
                        ORDER BY COUNT(*) DESC
                    ", referee.RefereeId).ToListAsync();

                    // Her hakem için takım bilgilerini alalım
                    var teamData = await _context.Database.SqlQueryRaw<RefereeTeamModel>(@"
                        SELECT TOP 5
                            T.Name as TeamName,
                            T.Logo as TeamLogo,
                            CAST(COUNT(*) AS INT) as TeamMatchCount
                        FROM Matches M
                        INNER JOIN Teams T ON (T.TeamId = M.HomeTeamId OR T.TeamId = M.AwayTeamId)
                        WHERE M.RefereeId = {0}
                        GROUP BY T.Name, T.Logo
                        ORDER BY COUNT(*) DESC
                    ", referee.RefereeId).ToListAsync();

                    // Ana kayıt
                    result.Add(new TopRefereeDetailsModel
                    {
                        RefereeId = referee.RefereeId,
                        RefereeName = referee.RefereeName,
                        ImgUrl = referee.ImgUrl,
                        TotalMatches = referee.TotalMatches,
                        KitName = null,
                        KitImagePath = null,
                        KitUsageCount = null,
                        TeamName = null,
                        TeamLogo = null,
                        TeamMatchCount = null,
                        TeamRank = null
                    });

                    // Forma kayıtları
                    int kitRank = 1;
                    foreach (var kit in kitData)
                    {
                        result.Add(new TopRefereeDetailsModel
                        {
                            RefereeId = referee.RefereeId,
                            RefereeName = referee.RefereeName,
                            ImgUrl = referee.ImgUrl,
                            TotalMatches = referee.TotalMatches,
                            KitName = kit.KitName,
                            KitImagePath = kit.KitImagePath,
                            KitUsageCount = kit.KitUsageCount,
                            TeamName = null,
                            TeamLogo = null,
                            TeamMatchCount = null,
                            TeamRank = null
                        });
                        kitRank++;
                    }

                    // Takım kayıtları
                    int teamRank = 1;
                    foreach (var team in teamData)
                    {
                        result.Add(new TopRefereeDetailsModel
                        {
                            RefereeId = referee.RefereeId,
                            RefereeName = referee.RefereeName,
                            ImgUrl = referee.ImgUrl,
                            TotalMatches = referee.TotalMatches,
                            KitName = null,
                            KitImagePath = null,
                            KitUsageCount = null,
                            TeamName = team.TeamName,
                            TeamLogo = team.TeamLogo,
                            TeamMatchCount = team.TeamMatchCount,
                            TeamRank = teamRank
                        });
                        teamRank++;
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
