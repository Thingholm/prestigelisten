using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Types
{
    public enum ResultType
    {
        Sejr,
        [Description("Top 3")]
        Top3,
        [Description("Top 5")]
        Top5,
        [Description("Top 10")]
        Top10,
        Bjergtrøje,
        Pointtrøje,
        [Description("1. dag i førertrøjen")]
        FørsteDagIFørertrøjen,
        [Description("2. dag i førertrøjen")]
        AndenDagIFørertrøjen,
        [Description("3. dag i førertrøjen")]
        TredjeDagIFørertrøjen,
        [Description("Øvrig dag i førertrøjen")]
        ØvrigDagIFørertrøjen,
        Etapesejr,
        Guld,
        Sølv,
        Bronze
    }
}
