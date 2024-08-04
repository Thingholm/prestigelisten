using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("rider_rankings_each_year_accumulated")]
    public class RiderRankingEachYearAccumulated : IModel, IModelPlacement
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("points")]
        public int? Points { get; set; }
        [Column("placement")]
        public int? Placement { get; set; }
    }
}
