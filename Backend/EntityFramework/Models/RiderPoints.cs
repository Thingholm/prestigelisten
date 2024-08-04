using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("rider_points")]
    public class RiderPoints : Model
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("points")]
        public int Points { get; set; }
    }
}
