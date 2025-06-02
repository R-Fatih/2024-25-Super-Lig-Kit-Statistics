namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class TopRefereeDetailsModel
    {
        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public string ImgUrl { get; set; }
        public int TotalMatches { get; set; }
        public string? KitName { get; set; }
        public string? KitImagePath { get; set; }
        public int? KitUsageCount { get; set; }
        public string? TeamName { get; set; }
        public string? TeamLogo { get; set; }
        public int? TeamMatchCount { get; set; }
        public int? TeamRank { get; set; }
    }
} 