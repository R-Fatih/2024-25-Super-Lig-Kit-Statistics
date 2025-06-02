namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class HomeAdvantageKitModel
    {
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int HomeMatches { get; set; }
        public int HomeWins { get; set; }
        public int HomeDraws { get; set; }
        public int HomeLosses { get; set; }
        public decimal HomeWinPercentage { get; set; }
        public decimal HomePointsPerMatch { get; set; }
        public int AwayMatches { get; set; }
        public int AwayWins { get; set; }
        public int AwayDraws { get; set; }
        public int AwayLosses { get; set; }
        public decimal AwayWinPercentage { get; set; }
        public decimal AwayPointsPerMatch { get; set; }
        public decimal HomeAdvantageIndex { get; set; }
    }

    public class GoalkeeperKitPerformanceModel
    {
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int MatchCount { get; set; }
        public int GoalsConceded { get; set; }
        public int CleanSheets { get; set; }
        public decimal GoalsPerMatch { get; set; }
        public decimal CleanSheetPercentage { get; set; }
        public decimal SaveEfficiency { get; set; }
    }
} 