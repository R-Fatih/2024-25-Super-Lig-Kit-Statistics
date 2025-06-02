using System.ComponentModel.DataAnnotations.Schema;

namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class TeamSeasonSummaryModel
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamLogo { get; set; }
        
        [NotMapped]
        public List<KitUsageSummary> PlayerKits { get; set; }
        
        [NotMapped]
        public List<KitUsageSummary> GoalkeeperKits { get; set; }
        
        [NotMapped]
        public List<OpponentMatchupModel> OpponentMatchups { get; set; }
        
        [NotMapped]
        public TeamPerformanceStats PerformanceStats { get; set; }
    }

    public class KitUsageSummary
    {
        public int KitId { get; set; }
        public string KitName { get; set; }
        public string KitImagePath { get; set; }
        public int TotalUsage { get; set; }
        public int HomeUsage { get; set; }
        public int AwayUsage { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public decimal WinPercentage { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public decimal PointsPerMatch { get; set; }
    }

    public class OpponentMatchupModel
    {
        public int OpponentId { get; set; }
        public string OpponentName { get; set; }
        public string OpponentLogo { get; set; }
        public string HomeKitUsed { get; set; }
        public string HomeKitImagePath { get; set; }
        public string AwayKitUsed { get; set; }
        public string AwayKitImagePath { get; set; }
        public string HomeGKKitUsed { get; set; }
        public string HomeGKKitImagePath { get; set; }
        public string AwayGKKitUsed { get; set; }
        public string AwayGKKitImagePath { get; set; }
        public int HomeWins { get; set; }
        public int HomeDraws { get; set; }
        public int HomeLosses { get; set; }
        public int AwayWins { get; set; }
        public int AwayDraws { get; set; }
        public int AwayLosses { get; set; }
        public string HomeScore { get; set; }
        public string AwayScore { get; set; }
    }

    public class TeamPerformanceStats
    {
        public int TotalMatches { get; set; }
        public int HomeMatches { get; set; }
        public int AwayMatches { get; set; }
        public int TotalWins { get; set; }
        public int TotalDraws { get; set; }
        public int TotalLosses { get; set; }
        public int TotalGoalsFor { get; set; }
        public int TotalGoalsAgainst { get; set; }
        public int TotalPoints { get; set; }
        public decimal WinPercentage { get; set; }
        public decimal PointsPerMatch { get; set; }
        public int DifferentKitsUsed { get; set; }
        public int DifferentGKKitsUsed { get; set; }
    }
} 