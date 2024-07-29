using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("races")]
    public class Race
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("active_span")]
        public string? ActiveSpan { get; set; }
        [Column("nation_id")]
        [ForeignKey(nameof(Nation))]
        public int? NationId { get; set; }
        public Nation? Nation { get; set; }
        [Column("race_classification_id")]
        [ForeignKey(nameof(RaceClassification))]
        public int RaceClassificationId { get; set; }
        public RaceClassification RaceClassification { get; set; }
        [Column("active")]
        public bool Active { get; set; }
        [Column("color_hex")]
        [MaxLength(6)]
        public string? ColorHex { get; set; }
    }
}
