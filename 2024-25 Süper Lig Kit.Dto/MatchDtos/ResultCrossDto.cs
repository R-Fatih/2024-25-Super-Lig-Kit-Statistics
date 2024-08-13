using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.MatchDtos
{

    


    public class Class1
    {
        public string homeTeam { get; set; }
        public string homeTeamLogo { get; set; }
        public List<Kit> kits { get; set; }
    }

    public class Kit
    {
        public string awayTeam { get; set; }
        public Homekit? homeKit { get; set; }
        public Awaykit? awayKit { get; set; }
    }

    public class Homekit
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

    public class Awaykit
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
