using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.RefereeDtos
{
    public class ResultRefereeDto
    {
        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public bool IsFifa { get; set; }
        public string ImgUrl { get; set; }
    }
}
