namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class TeamKitDiversityModel
    {
        public string TeamName { get; set; }
        public int TotalMatches { get; set; }
        public int DifferentKitsUsed { get; set; }
        public int DifferentGKKitsUsed { get; set; }
        public decimal KitChangeFrequency { get; set; }
        public string MostUsedKit { get; set; }
        public int MostUsedKitCount { get; set; }
        public decimal KitLoyaltyPercentage { get; set; }
    }
} 