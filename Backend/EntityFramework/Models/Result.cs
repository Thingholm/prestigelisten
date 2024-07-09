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
    [Table("results")]
    public class Result
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("race_id")]
        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        public Race Race { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("result_type")]
        [EnumDataType(typeof(ResultType))]
        public ResultType ResultType { get; set; }
        [Column("placement")]
        public int? Placement { get; set; }
        [Column("race_date_id")]
        [ForeignKey(nameof(RaceDate))]
        public int? RaceDateId { get; set; }
        public RaceDate RaceDate { get; set; }
    }

}
