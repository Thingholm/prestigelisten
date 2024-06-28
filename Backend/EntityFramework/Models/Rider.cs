using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Rider
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int NationId { get; set; }
        public Nation Nation { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public bool Active { get; set; }
    }
}
