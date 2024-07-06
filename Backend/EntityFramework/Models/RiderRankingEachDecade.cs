using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("rider_rankings_each_decade")]
    public class RiderRankingEachDecade
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("decade")]
        public int Decade { get; set; }
        [Column("points")]
        public int? Points { get; set; }
        [Column("placement")]
        public int? Placement { get; set; }
    }
}
