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
    public class PointSystem
    {
        public int Id { get; set; }
        public int RaceClassificationId { get; set; }
        public RaceClassification RaceClassification { get; set; }
        public ResultType ResultType { get; set; }
        public int Points { get; set; }
    }
}
