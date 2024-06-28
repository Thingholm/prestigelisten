using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class NationRankingEachYear
    {
        public int Id { get; set; }
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        public int Year { get; set; }
        public int? Points { get; set; }
        public int? Placement { get; set; }
        public int NumberOfResults { get; set; }
    }
}
