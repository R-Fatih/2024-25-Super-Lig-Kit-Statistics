namespace _2024_25_Süper_Lig_Kit.WebUI.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Match> HomeMatches { get; set; }
        public List<Match> AwayMatches { get; set; }
        public List<Jersey> Jerseys { get; set; }
    }
}
