namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class RefereeWeeklyKitModel
    {
        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public string ImgUrl { get; set; }
        public int Week { get; set; }
        public int MainId { get; set; }
        public string KitName { get; set; }
        public string KitImagePath { get; set; }
        public string CombinedKitImagePath { get; set; }
        public int UsageCount { get; set; }
    }
} 