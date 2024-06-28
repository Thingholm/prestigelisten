using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class RiderRankingEachYearAccumulated
    {
        public int Id { get; set; }
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        public int Year { get; set; }
        public int Points { get; set; }
        public int? Placement { get; set; }
    }
}
