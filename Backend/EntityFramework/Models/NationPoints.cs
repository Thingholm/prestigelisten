using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Models
{
    [Table("nation_points")]
    public class NationPoints : IModel
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("nation_id")]
        [ForeignKey(nameof(Nation))]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [Column("points")]
        public int Points { get; set; }
    }
}
