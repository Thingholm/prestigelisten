using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public interface ModelPlacement
    {
        public int? Points { get; set; }
        public int? Placement { get; set; }
    }
}
