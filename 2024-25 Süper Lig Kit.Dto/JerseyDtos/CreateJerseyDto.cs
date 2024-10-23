using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_25_Süper_Lig_Kit.Dto.JerseyDtos
{
    public class CreateJerseyDto
    {
        public string Name { get; set; }
      
        public int TeamId { get; set; }
        public bool IsKeeper { get; set; }
    }
}
