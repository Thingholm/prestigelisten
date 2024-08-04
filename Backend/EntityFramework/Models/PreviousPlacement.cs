using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("previous_placements")]
    public class PreviousPlacement : IModel
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("rider_id")]
        [ForeignKey(nameof(Rider))]
        public int RiderId { get; set; }
        public Rider Rider { get; set; }
        [Column("result_id")]
        [ForeignKey(nameof(Result))]
        public int ResultId { get; set; }
        public Result Result { get; set; }
        [Column("prev_points")]
        public int PrevPoints { get; set; }
        [Column("prev_placement")]
        public int PrevPlacement {  get; set; }
        [Column("new_points")]
        public int NewPoints { get; set; }
        [Column("new_placement")]
        public int NewPlacement { get; set; }

    }
}
