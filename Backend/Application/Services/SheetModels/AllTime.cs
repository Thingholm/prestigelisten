using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SheetModels
{
    public class AllTime
    {
        public int Placement { get; set; }
        public string RiderName { get; set; }
        public int Points { get; set; }
        public string Nation { get; set; }
        public int? BirthYear { get; set; }

        public AllTime(IList<Object> columns)
        {
            Placement = int.Parse(columns[0]?.ToString());
            RiderName = columns[1]?.ToString();
            Points = int.Parse(columns[2]?.ToString());
            Nation = columns[3]?.ToString();
            try
            {
                BirthYear = int.Parse(columns[4]?.ToString());
            }
            catch
            {
            }
        }

        public AllTime()
        {

        }
    }
}
