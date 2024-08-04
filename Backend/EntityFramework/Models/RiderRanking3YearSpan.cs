using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("rider_rankings_3_year_span")]
    public class RiderRanking3YearSpan : Model, ModelPlacement
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("start_year")]
        public int StartYear { get; set; }
        [Column("end_year")]
        public int EndYear { get; set; }
        [Column("points")]
        public int? Points { get; set; }
        [Column("placement")]
        public int? Placement { get; set; }
    }
}
