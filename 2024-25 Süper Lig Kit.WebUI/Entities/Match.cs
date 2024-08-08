namespace _2024_25_Süper_Lig_Kit.WebUI.Entities
{
    public class Match
    {
        public int MatchId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public int HomeTeamJerseyImageId { get; set; }
        public int HomeTeamJerseyImageGKId { get; set; }

        public int RefereeJerseyImageId { get; set; }
        public int AwayTeamJerseyImageId { get; set; }
        public int AwayTeamJerseyImageGKId { get; set; }

        public int? HomeMS { get; set; }
        public int? AwayMS { get; set; }
        public int? Maçkolik { get; set; }
        public DateTime? Date { get; set; }
        public int MainId { get; set; }
        public int Week { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public JerseyImage RefereeJerseyImage { get; set; }
        public JerseyImage HomeTeamJerseyImage { get; set; }
        public JerseyImage AwayTeamJerseyImage { get; set; }
        public JerseyImage HomeTeamJerseyImageGK { get; set; }
        public JerseyImage AwayTeamJerseyImageGK { get; set; }
        public int RefereeId { get; set; }
        public Referee Referee { get; set; }
    }
}
