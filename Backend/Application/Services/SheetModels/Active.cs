using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SheetModels
{
    public class Active
    {
        public string Name { get; set; }
        public string Team { get; set; }

        public Active(IList<Object> columns)
        {
            Name = columns[2].ToString();
            Team = columns[5].ToString();
        }

        public Active()
        {

        }
    }
}
