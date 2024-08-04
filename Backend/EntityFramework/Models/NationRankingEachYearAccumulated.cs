using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("nation_rankings_each_year_accumulated")]
    public class NationRankingEachYearAccumulated : IModel, IModelPlacement
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("nation_id")]
        [ForeignKey(nameof(Nation))]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [Column("year")]
        public int Year { get; set; }
        [Column("points")]
        public int? Points { get; set; }
        [Column("placement")]
        public int? Placement { get; set; }
        [Column("number_of_results")]
        public int NumberOfResults { get; set; }
    }
}
