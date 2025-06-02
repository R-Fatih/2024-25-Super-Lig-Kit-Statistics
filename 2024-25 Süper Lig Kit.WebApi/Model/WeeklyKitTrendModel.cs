namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class WeeklyKitTrendModel
    {
        public int Week { get; set; }
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int KitUsageCount { get; set; }
        public int IsHome { get; set; }
        public DateTime? MatchDate { get; set; }
    }
} 