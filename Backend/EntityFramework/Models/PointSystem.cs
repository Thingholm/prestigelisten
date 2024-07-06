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
    [Table("point_system")]
    public class PointSystem
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("race_classification_id")]
        [ForeignKey(nameof(RaceClassification))]
        public int RaceClassificationId { get; set; }
        public RaceClassification RaceClassification { get; set; }
        [Column("result_type")]
        [EnumDataType(typeof(ResultType))]
        public ResultType ResultType { get; set; }
        [Column("points")]
        public int Points { get; set; }
    }
}
