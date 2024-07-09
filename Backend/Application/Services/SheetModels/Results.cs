using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.SheetModels
{
    public class Results
    {
        public IList<Object> Data { get; set; }
        public Results(IList<Object> objects) 
        {
            Data = objects;
        }
    }
}
