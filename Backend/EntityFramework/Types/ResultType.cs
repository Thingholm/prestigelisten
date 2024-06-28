using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Types
{
    public enum ResultType
    {
        Sejr,
        [Display(Name = "Top 3")]
        Top3,
        [Display(Name = "Top 5")]
        Top5,
        [Display(Name = "Top 10")]
        Top10,
        Bjergtrøje,
        Pointtrøje,
        [Display(Name = "1. dag i førertrøjen")]
        FørsteDagIFørertrøjen,
        [Display(Name = "2. dag i førertrøjen")]
        AndenDagIFørertrøjen,
        [Display(Name = "3. dag i førertrøjen")]
        TredjeDagIFørertrøjen,
        [Display(Name = "Øvrig dag i førertrøjen")]
        ØvrigDagIFørertrøjen,
        Etapesejr,
        Guld,
        Sølv,
        Bronze
    }
}
