namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class RefereeAnalysisModel
    {
        public string RefereeName { get; set; }
        public string Body { get; set; }
        public int KitCount { get; set; }
        public int TotalMatches { get; set; }
        public decimal KitUsagePercentage { get; set; }
        public bool IsFifa { get; set; }
    }

    public class RefereeTeamHarmonyModel
    {
        public string RefereeName { get; set; }
        public string TeamName { get; set; }
        public string RefereeKit { get; set; }
        public string TeamKit { get; set; }
        public int MatchCount { get; set; }
        public int HasClash { get; set; }
    }

    public class KitClashResolutionModel
    {
        public string RefereeName { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public string HomeKit { get; set; }
        public string AwayKit { get; set; }
        public string RefereeKit { get; set; }
        public bool HasClash { get; set; }
        public string ClashType { get; set; }
    }
} 