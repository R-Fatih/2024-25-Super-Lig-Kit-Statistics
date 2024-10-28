namespace _2024_25_Süper_Lig_Kit.WebUI.Models
{




    public class TeamDownDto
    {
        public string newTeam { get; set; }
        public string homeTeamLogo { get; set; }
        public Kit[] kits { get; set; }
    }

    public class Kit
    {
        public int week { get; set; }
        public Kit1 kit { get; set; }
        public bool isBye { get; set; }
    }

    public class Kit1
    {
        public int jerseyImageId { get; set; }
        public string imgPath { get; set; }
        public int jerseyId { get; set; }
        public object jersey { get; set; }
        public object refereeJerseyImageMatches { get; set; }
        public object homeTeamJerseyImageMatches { get; set; }
        public object awayTeamJerseyImageMatches { get; set; }
        public object homeTeamJerseyImageGKMatches { get; set; }
        public object awayTeamJerseyImageGKMatches { get; set; }
    }

}
