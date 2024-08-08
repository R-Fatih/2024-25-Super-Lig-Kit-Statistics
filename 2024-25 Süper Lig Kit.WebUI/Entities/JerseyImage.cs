namespace _2024_25_Süper_Lig_Kit.WebUI.Entities
{
    public class JerseyImage
    {
        public int JerseyImageId { get; set; }
        public string ImgPath { get; set; }
        public int JerseyId { get; set; }
        public Jersey? Jersey { get; set; }
        public List<Match> RefereeJerseyImageMatches { get; set; }
        public List<Match> HomeTeamJerseyImageMatches { get; set; }
        public List<Match> AwayTeamJerseyImageMatches { get; set; }
        public List<Match> HomeTeamJerseyImageGKMatches { get; set; }
        public List<Match> AwayTeamJerseyImageGKMatches { get; set; }

    }
}
