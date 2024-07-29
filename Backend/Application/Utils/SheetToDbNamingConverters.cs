using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class SheetToDbNamingConverters
    {
        public static string RaceNameConverter(string raceName)
        {
            switch (raceName)
            {
                case "Verdensmester i enkeltstart":
                case "VM-sølv i enkeltstart":
                case "VM-bronze i enkeltstart":
                    return "VM i enkeltstart";
                case "Verdensmester":
                case "VM-sølv":
                case "VM-bronze":
                case "4. plads ved VM":
                case "5. plads ved VM":
                    return "VM i linjeløb";
                case "Olympisk mester i enkeltstart (>1994)":
                case "OL-sølv i enkeltstart (>1994)":
                case "OL-bronze i enkeltstart (>1994)":
                    return "OL i enkeltstart (>1994)";
                case "Olympisk mester i enkeltstart (<1994)":
                case "OL-sølv i enkeltstart (<1994)":
                case "OL-bronze i enkeltstart (<1994)":
                    return "OL i enkeltstart (<1994)";
                case "Olympisk mester (>1994)":
                case "OL-sølv (>1994)":
                case "OL-bronze (>1994)":
                    return "OL i linjeløb (>1994)";
                case "Olympisk mester (<1994)":
                case "OL-sølv (<1994)":
                case "OL-bronze (<1994)":
                    return "OL i linjeløb (<1994)";
                case "Europamester i enkeltstart":
                case "EM-sølv i enkeltstart":
                case "EM-bronze i enkeltstart":
                    return "EM i enkeltstart";
                case "Europamester":
                case "EM-sølv":
                case "EM-bronze":
                    return "EM i linjeløb";
                default:
                    return raceName;
            }
        }
        public static string GetRaceName(string raceString)
        {
            string raceName = RaceNameConverter(raceString);
            if (raceName.Contains("etape"))
            {
                raceName = raceName.Split("etape af ")[1];
            }
            else if (raceName.Contains("plads i"))
            {
                raceName = raceName.Split("plads i ")[1];
            }
            else if (raceName.Contains("OL 12 timers løb"))
            {
                raceName = raceName.Split(" - ")[0];
            }
            else if (raceName.Contains("trøjen i "))
            {
                raceName = raceName.Split("trøjen i ")[1];
            }
            else if (raceName.Contains("trøje i "))
            {
                raceName = raceName.Split("trøje i ")[1];
            }
            else if (raceName.Contains("e 2018"))
            {
                raceName = raceName.Split(" 2")[0];
            }
            if (raceName.Contains(" ("))
            {
                raceName = raceName.Split(" (")[0];
            }
            return raceName;
        }
    }
}
