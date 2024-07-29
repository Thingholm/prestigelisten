using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("riders")]
    public class Rider
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("first_name")] 
        public string? FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("birth_year")]
        public int? BirthYear { get; set; }
        [Column("nation_id")]
        [ForeignKey(nameof(Nation))]
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        [Column("team_id")]
        [ForeignKey(nameof(Team))]
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        [Column("active")]
        public bool Active { get; set; }
    }
}
