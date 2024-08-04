using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("race_dates")]
    public class RaceDate : IModel
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("race_id")]
        [ForeignKey(nameof(Race))]
        public int RaceId { get; set; }
        public Race Race { get; set; }
        [Column("stage")]
        public int? Stage { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
    }
}
