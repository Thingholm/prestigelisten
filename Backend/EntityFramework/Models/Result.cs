using EntityFramework.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Result
    {
        public int Id { get; set; }
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        public ResultType ResultType { get; set; }
        public int? Placement { get; set; }
    }

}
