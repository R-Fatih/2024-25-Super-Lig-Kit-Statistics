using _2024_25_Süper_Lig_Kit.Dto.JerseyImageDtos;
using _2024_25_Süper_Lig_Kit.Dto.RefereeDtos;
using _2024_25_Süper_Lig_Kit.Dto.TeamDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.MatchDtos
{
    public class ResultMatchDto
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
        public int RefereeId { get; set; }
        public ResultTeamDto HomeTeam { get; set; }
        public ResultTeamDto AwayTeam { get; set; }
        public ResultRefereeDto Referee { get; set; }
        public ResultJerseyImageDto HomeTeamJerseyImage { get; set; }
        public ResultJerseyImageDto HomeTeamJerseyImageGK { get; set; }
        public ResultJerseyImageDto RefereeJerseyImage { get; set; }
        public ResultJerseyImageDto AwayTeamJerseyImage { get; set; }
        public ResultJerseyImageDto AwayTeamJerseyImageGK { get; set; } 
    }
}
