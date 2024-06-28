using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActiveSpan { get; set; }
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        public int RaceClassificationId { get; set; }
        public RaceClassification RaceClassification { get; set; }
        public bool Active { get; set; }
        public string ColorHex { get; set; }
    }
}
