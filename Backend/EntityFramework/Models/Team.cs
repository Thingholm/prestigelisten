﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    [Table("team")]
    public class Team
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        [Column("name")]    
        public string Name { get; set; }
    }
}
