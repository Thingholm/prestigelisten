using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("previous_nationalities")]
    public class PreviousNationalities
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("nation_id")]
        [ForeignKey(nameof(Nation))]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [Column("start_year")]
        [MaxLength(4)]
        public int? StartYear { get; set; }
        [Column("end_year")]
        [MaxLength(4)]
        public int EndYear { get; set; }
    }
}
