namespace Süper_Lig_Forma_İstatistikleri.Api.Model
{
    public class KitSuccessCorrelationModel
    {
        public string TeamName { get; set; }
        public string Body { get; set; }
        public int TotalMatches { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public decimal WinPercentage { get; set; }
        public decimal PointsPerMatch { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
    }
} 