namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class KitUsageHeatmapModel
    {
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int KitId { get; set; }
        public int UsageCount { get; set; }
        public decimal UsagePercentage { get; set; }
        public string LogoUrl { get; set; }
    }

    public class ScoreDistributionModel
    {
        public string Body { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public int MatchCount { get; set; }
        public decimal AverageGoalsFor { get; set; }
        public decimal AverageGoalsAgainst { get; set; }
    }

    public class TimeSeriesModel
    {
        public int Week { get; set; }
        public DateTime? Date { get; set; }
        public int TotalKitsUsed { get; set; }
        public int DifferentKitsUsed { get; set; }
        public decimal KitDiversityIndex { get; set; }
    }

    public class NetworkAnalysisModel
    {
        public string TeamName { get; set; }
        public string KitName { get; set; }
        public string RefereeName { get; set; }
        public int ConnectionStrength { get; set; }
        public string RelationType { get; set; }
    }

    public class CriticalMatchKitModel
    {
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int TotalScore { get; set; }
        public int MatchCount { get; set; }
        public decimal AverageScore { get; set; }
        public bool IsHighScoring { get; set; }
        public int Week { get; set; }
    }
} 