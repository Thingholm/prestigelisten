using EntityFramework.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Utils
{
    public static class ResultTypeConverters
    {
        public static ResultType Convert(string result)
        {
            if (result == null) throw new ArgumentNullException("result");

            if (result.Contains("etape"))
            {
                return ResultType.Etapesejr;
            }
            else if (result.Contains("2. plads") || result.Contains("3. plads"))
            {
                return ResultType.Top3;
            }
            else if (result.Contains("4. plads") || result.Contains("5. plads"))
            {
                return ResultType.Top5;
            }
            else if (result.Contains("6. plads") || result.Contains("7. plads") || result.Contains("8. plads") || result.Contains("9. plads") || result.Contains("10. plads"))
            {
                return ResultType.Top10;
            }
            else if (result.Contains("Pointtrøje"))
            {
                return ResultType.Pointtrøje;
            }
            else if (result.Contains("Bjergtrøje"))
            {
                return ResultType.Bjergtrøje;
            }
            else if (result.Contains("1. dag i førertrøjen"))
            {
                return ResultType.FørsteDagIFørertrøjen;
            }
            else if (result.Contains("2. dag i førertrøjen"))
            {
                return ResultType.AndenDagIFørertrøjen;
            }
            else if (result.Contains("3. dag i førertrøjen"))
            {
                return ResultType.TredjeDagIFørertrøjen;
            }
            else if (result.Contains("Øvrige dage i førertrøjen"))
            {
                return ResultType.ØvrigDagIFørertrøjen;
            }
            else if (result.Contains("Verdensmester") || result.Contains("Europamester") || result.Contains("Olympisk mester") || result.Contains("guld"))
            {
                return ResultType.Guld;
            }
            else if (result.Contains("sølv"))
            {
                return ResultType.Sølv;
            }
            else if (result.Contains("bronze"))
            {
                return ResultType.Bronze;
            }
            else
            {
                return ResultType.Sejr;
            }
        }

        public static string GetDescription(this ResultType resultTypeEnum)
        {
            FieldInfo field = resultTypeEnum.GetType().GetField(resultTypeEnum.ToString());

            DescriptionAttribute attribute = field?.GetCustomAttribute<DescriptionAttribute>();

            return attribute == null ? resultTypeEnum.ToString() : attribute.Description;
        }
    }
}
