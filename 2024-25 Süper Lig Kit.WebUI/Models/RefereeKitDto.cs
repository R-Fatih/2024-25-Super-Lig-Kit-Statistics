namespace _2024_25_Süper_Lig_Kit.WebUI.Models
{
    

       

        public class RefereeKitDto
        {
            public int week { get; set; }
            public Kitt[] kit { get; set; }
        }

        public class Kitt
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
