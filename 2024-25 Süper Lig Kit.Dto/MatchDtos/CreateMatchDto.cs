using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.MatchDtos
{
    public class CreateMatchDto
    {
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
    }
}
