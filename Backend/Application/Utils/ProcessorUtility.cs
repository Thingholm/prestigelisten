using EntityFramework.Data;
using EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utils
{
    public static class ProcessorUtility
    {
        public static Race FindRace(AppDbRepository appDbRepository, string raceString)
        {
            string raceName = SheetToDbNamingConverters.GetRaceName(raceString);

            Race race = appDbRepository.Races.FirstOrDefault(r =>
                raceName.ToLower() == r.Name.ToLower()
                && (raceString.Contains(" (") ? r.ActiveSpan == "(" + raceString.Split("(")[1] : true)
            );

            return race;
        }

        public static List<RiderRankingEachYear> GetRiderPlacements(List<RiderPoints> riderPoints, int year) 
        {
            List<RiderRankingEachYear> riderRankingEachYearList = new List<RiderRankingEachYear>();

            int curPlacement = 1;
            RiderRankingEachYear prevRider = new RiderRankingEachYear();
            foreach (RiderPoints rider in riderPoints.OrderByDescending(r => r.Points))
            {
                if (prevRider.RiderId == null) 
                {
                    RiderRankingEachYear riderRanking = new RiderRankingEachYear();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Year = year;
                    riderRanking.Points = rider.Points;
                    riderRanking.Placement = curPlacement;

                    riderRankingEachYearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
                else
                {
                    RiderRankingEachYear riderRanking = new RiderRankingEachYear();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Year = year;
                    riderRanking.Points = rider.Points;

                    if (rider.Points == prevRider.Points)
                    {
                        riderRanking.Placement = prevRider.Placement;
                    }
                    else
                    {
                        riderRanking.Placement = curPlacement;
                    }

                    riderRankingEachYearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
            }

            return riderRankingEachYearList;
        }

        public static List<RiderRankingEachYearAccumulated> GetRiderPlacementsAccumulated(List<RiderPoints> riderPoints, int year)
        {
            List<RiderRankingEachYearAccumulated> riderRankingEachYearList = new List<RiderRankingEachYearAccumulated>();

            int curPlacement = 1;
            RiderRankingEachYearAccumulated prevRider = new RiderRankingEachYearAccumulated();
            foreach (RiderPoints rider in riderPoints.OrderByDescending(r => r.Points))
            {
                if (prevRider.RiderId == null)
                {
                    RiderRankingEachYearAccumulated riderRanking = new RiderRankingEachYearAccumulated();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Year = year;
                    riderRanking.Points = rider.Points;
                    riderRanking.Placement = curPlacement;

                    riderRankingEachYearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
                else
                {
                    RiderRankingEachYearAccumulated riderRanking = new RiderRankingEachYearAccumulated();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Year = year;
                    riderRanking.Points = rider.Points;

                    if (rider.Points == prevRider.Points)
                    {
                        riderRanking.Placement = prevRider.Placement;
                    }
                    else
                    {
                        riderRanking.Placement = curPlacement;
                    }

                    riderRankingEachYearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
            }

            return riderRankingEachYearList;
        }
        public static List<NationRankingEachYear> GetNationsPlacements(List<NationPoints> nationPoints, int year)
        {
            List<NationRankingEachYear> nationRankingEachYearList = new List<NationRankingEachYear>();

            int curPlacement = 1;
            NationRankingEachYear prevNation = new NationRankingEachYear();
            foreach (NationPoints nation in nationPoints.OrderByDescending(r => r.Points))
            {
                if (prevNation.NationId == null)
                {
                    NationRankingEachYear nationRanking = new NationRankingEachYear();

                    nationRanking.NationId = nation.NationId;
                    nationRanking.Year = year;
                    nationRanking.Points = nation.Points;
                    nationRanking.Placement = curPlacement;

                    nationRankingEachYearList.Add(nationRanking);

                    prevNation = nationRanking;
                    curPlacement++;
                }
                else
                {
                    NationRankingEachYear nationRanking = new NationRankingEachYear();

                    nationRanking.NationId = nation.NationId;
                    nationRanking.Year = year;
                    nationRanking.Points = nation.Points;

                    if (nation.Points == prevNation.Points)
                    {
                        nationRanking.Placement = prevNation.Placement;
                    }
                    else
                    {
                        nationRanking.Placement = curPlacement;
                    }

                    nationRankingEachYearList.Add(nationRanking);

                    prevNation = nationRanking;
                    curPlacement++;
                }
            }

            return nationRankingEachYearList;
        }

        public static List<NationRankingEachYearAccumulated> GetNationsPlacementsAccumulated(List<NationPoints> nationPoints, int year)
        {
            List<NationRankingEachYearAccumulated> nationRankingEachYearList = new List<NationRankingEachYearAccumulated>();

            int curPlacement = 1;
            NationRankingEachYearAccumulated prevNation = new NationRankingEachYearAccumulated();
            foreach (NationPoints nation in nationPoints.OrderByDescending(r => r.Points))
            {
                if (prevNation.NationId == null)
                {
                    NationRankingEachYearAccumulated nationRanking = new NationRankingEachYearAccumulated();

                    nationRanking.NationId = nation.NationId;
                    nationRanking.Year = year;
                    nationRanking.Points = nation.Points;
                    nationRanking.Placement = curPlacement;

                    nationRankingEachYearList.Add(nationRanking);

                    prevNation = nationRanking;
                    curPlacement++;
                }
                else
                {
                    NationRankingEachYearAccumulated nationRanking = new NationRankingEachYearAccumulated();

                    nationRanking.NationId = nation.NationId;
                    nationRanking.Year = year;
                    nationRanking.Points = nation.Points;

                    if (nation.Points == prevNation.Points)
                    {
                        nationRanking.Placement = prevNation.Placement;
                    }
                    else
                    {
                        nationRanking.Placement = curPlacement;
                    }

                    nationRankingEachYearList.Add(nationRanking);

                    prevNation = nationRanking;
                    curPlacement++;
                }
            }

            return nationRankingEachYearList;
        }

        public static List<RiderRankingEachDecade> GetRiderPlacementsEachDecade(List<RiderPoints> riderPoints, int year)
        {
            year = year == DateTime.Now.Year ? int.Parse(year.ToString().Remove(3, 1) + "0") + 9 : year;
            List<RiderRankingEachDecade> riderRankingEachDecadeList = new List<RiderRankingEachDecade>();

            int curPlacement = 1;
            RiderRankingEachDecade prevRider = new RiderRankingEachDecade();
            foreach (RiderPoints rider in riderPoints.OrderByDescending(r => r.Points))
            {
                if (prevRider.RiderId == null)
                {
                    RiderRankingEachDecade riderRanking = new RiderRankingEachDecade();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Decade = year - 9;
                    riderRanking.Points = rider.Points;
                    riderRanking.Placement = curPlacement;

                    riderRankingEachDecadeList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
                else
                {
                    RiderRankingEachDecade riderRanking = new RiderRankingEachDecade();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.Decade = year - 9;
                    riderRanking.Points = rider.Points;

                    if (rider.Points == prevRider.Points)
                    {
                        riderRanking.Placement = prevRider.Placement;
                    }
                    else
                    {
                        riderRanking.Placement = curPlacement;
                    }

                    riderRankingEachDecadeList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
            }

            return riderRankingEachDecadeList;
        }

        public static List<RiderRanking3YearSpan> GetRiderPlacements3YearSpan(List<RiderPoints> riderPoints, int startYear, int endYear)
        {
            List<RiderRanking3YearSpan> riderRanking3YearList = new List<RiderRanking3YearSpan>();

            int curPlacement = 1;
            RiderRanking3YearSpan prevRider = new RiderRanking3YearSpan();
            foreach (RiderPoints rider in riderPoints.OrderByDescending(r => r.Points))
            {
                if (prevRider.RiderId == null)
                {
                    RiderRanking3YearSpan riderRanking = new RiderRanking3YearSpan();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.EndYear = endYear;
                    riderRanking.StartYear = startYear;
                    riderRanking.Points = rider.Points;
                    riderRanking.Placement = curPlacement;

                    riderRanking3YearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
                else
                {
                    RiderRanking3YearSpan riderRanking = new RiderRanking3YearSpan();

                    riderRanking.RiderId = rider.RiderId;
                    riderRanking.EndYear = endYear;
                    riderRanking.StartYear = startYear;
                    riderRanking.Points = rider.Points;

                    if (rider.Points == prevRider.Points)
                    {
                        riderRanking.Placement = prevRider.Placement;
                    }
                    else
                    {
                        riderRanking.Placement = curPlacement;
                    }

                    riderRanking3YearList.Add(riderRanking);

                    prevRider = riderRanking;
                    curPlacement++;
                }
            }

            return riderRanking3YearList;
        }
    }
}
