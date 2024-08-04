using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public interface IModelPlacement
    {
        public int? Points { get; set; }
        public int? Placement { get; set; }
    }
}
