using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.JerseyDtos
{
    public class ResultJerseyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string Shorts { get; set; }
        public string Socks { get; set; }
        public int TeamId { get; set; }
        public bool IsKeeper { get; set; }
    }
}
