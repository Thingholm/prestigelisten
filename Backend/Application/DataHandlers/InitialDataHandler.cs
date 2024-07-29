using Application.Services.SheetModels;
using Application.Utils;
using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Processors
{
    public class InitialDataHandler
    {
        public List<Result> resultList = new List<Result>();
        public List<RiderPoints> riderPointsList = new List<RiderPoints>();
        public List<RiderRankingEachYear> riderRankingEachYearList = new List<RiderRankingEachYear>();
        public List<RiderRankingEachYearAccumulated> riderRankingEachYearAccumulatedList = new List<RiderRankingEachYearAccumulated>();
        public List<NationPoints> nationPointsList = new List<NationPoints>();
        public List<NationRankingEachYear> nationRankingEachYearList = new List<NationRankingEachYear>();
        public List<NationRankingEachYearAccumulated> nationRankingEachYearAccumulatedList = new List<NationRankingEachYearAccumulated>();
        public List<RiderRankingEachDecade> riderRankingEachDecades = new List<RiderRankingEachDecade>();
        public List<RiderRanking3YearSpan> riderRanking3YearSpanList = new List<RiderRanking3YearSpan>();

        public void ProcessAllResultsFromSheet(List<Results> results, AppDbRepository appDbRepository)
        {
            Results headerRow = results[0];
            foreach (Results row in results.Skip(1).Reverse())
            {
                int year = int.Parse(row.Data[0].ToString());
                for (int i = 1; i < row.Data.Count; i++)
                {
                    Result newResult = new Result();
                    Object result = row.Data[i];

                    if (result == "" || result == null) continue;

                    string column = headerRow.Data[i].ToString();
                    Race race = ProcessorUtility.FindRace(appDbRepository, column);
                    newResult.RaceId = race.Id;

                    Rider rider = appDbRepository.Riders.FirstOrDefault(r => r.FirstName != null ? $"{r.FirstName} {r.LastName}".ToLower() == result.ToString().ToLower() : $"{r.LastName}".ToLower() == result.ToString().ToLower());
                    if (rider == null) continue;
                    newResult.RiderId = rider.Id;

                    newResult.ResultType = ResultTypeConverters.Convert(column);

                    if (column.Contains("plads"))
                    {
                        newResult.Placement = int.Parse(column.Split(". plads")[0]);
                    }

                    if (year == DateTime.Now.Year)
                    {
                        if (column.Contains("etape"))
                        {
                            newResult.RaceDateId = appDbRepository.RaceDates.FirstOrDefault(rd => rd.RaceId == newResult.RaceId && rd.Stage == int.Parse(column.Split(". etape")[0]))?.Id;
                        }
                        else
                        {
                            newResult.RaceDateId = appDbRepository.RaceDates.FirstOrDefault(rd => rd.RaceId == newResult.RaceId)?.Id;
                        }
                    }
                    newResult.year = year;

                    resultList.Add(newResult);
                }
            }
        }

        public void ProcessAllResultsFromDb(AppDbRepository appDbRepository)
        {
            List<RiderPoints> riderPointsEachDecade = new List<RiderPoints>();

            for (int i = 1886; i <= DateTime.Now.Year; i++)
            {
                List<RiderPoints> riderRankingsThisYear = new List<RiderPoints>();
                List<NationPoints> nationRankingsThisYear = new List<NationPoints>();
                foreach (Result result in appDbRepository.Results.FindAll(r => r.year == i))
                {
                    int points = appDbRepository.PointSystems.FirstOrDefault(p => p.RaceClassificationId == result.Race.RaceClassificationId && p.ResultType == result.ResultType).Points;
                    int nationId = result.Rider.NationId;

                    if (riderPointsList.Any(r => r.RiderId == result.RiderId))
                    {
                        riderPointsList.FirstOrDefault(r => r.RiderId == result.RiderId).Points += points;
                    }
                    else
                    {
                        RiderPoints newRider = new RiderPoints();
                        newRider.RiderId = result.RiderId;
                        newRider.Points = points;
                        riderPointsList.Add(newRider);
                    }

                    if (riderPointsEachDecade.Any(r => r.RiderId == result.RiderId))
                    {
                        riderPointsEachDecade.FirstOrDefault(r => r.RiderId == result.RiderId).Points += points;
                    }
                    else
                    {
                        RiderPoints newRider = new RiderPoints();
                        newRider.RiderId = result.RiderId;
                        newRider.Points = points;
                        riderPointsEachDecade.Add(newRider);
                    }

                    if (riderRankingsThisYear.Any(r => r.RiderId == result.RiderId))
                    {
                        riderRankingsThisYear.FirstOrDefault(r => r.RiderId == result.RiderId).Points += points;
                    }
                    else
                    {
                        RiderPoints newRider = new RiderPoints();
                        newRider.RiderId = result.RiderId;
                        newRider.Points = points;
                        riderRankingsThisYear.Add(newRider);
                    }

                    if (result.Race.RaceClassificationId < 12 || result.Race.RaceClassificationId > 15)
                    {
                        if (appDbRepository.PreviousNationalities.Any(pn => pn.RiderId == result.Rider.Id))
                        {
                            if (appDbRepository.PreviousNationalities.Any(pn => pn.StartYear != null && pn.RiderId == result.Rider.Id))
                            {
                                PreviousNationalities previousNationality = appDbRepository.PreviousNationalities.FirstOrDefault(pn => pn.RiderId == result.RiderId && pn.StartYear <= i && pn.EndYear >= i);
                                if (previousNationality != null)
                                {
                                    nationId = previousNationality.NationId;
                                }
                            }
                            else
                            {
                                PreviousNationalities previousNationality = appDbRepository.PreviousNationalities.FirstOrDefault(pn => pn.RiderId == result.RiderId && pn.EndYear >= i);
                                if (previousNationality != null)
                                {
                                    nationId = previousNationality.NationId;
                                }
                            }

                        }
                        if (nationPointsList.Any(n => n.NationId == nationId))
                        {
                            nationPointsList.FirstOrDefault(n => n.NationId == nationId).Points += points;
                        }
                        else
                        {
                            NationPoints newNation = new NationPoints();
                            newNation.NationId = nationId;
                            newNation.Points = points;
                            nationPointsList.Add(newNation);
                        }

                        if (nationRankingsThisYear.Any(n => n.NationId == nationId))
                        {
                            nationRankingsThisYear.FirstOrDefault(n => n.NationId == nationId).Points += points;
                        }
                        else
                        {
                            NationPoints newNation = new NationPoints();
                            newNation.NationId = nationId;
                            newNation.Points = points;
                            nationRankingsThisYear.Add(newNation);
                        }
                    }
                }
                List<RiderRankingEachYear> riderRankingEachYear = ProcessorUtility.GetRiderPlacements(riderRankingsThisYear, i);
                riderRankingEachYearList.AddRange(riderRankingEachYear);
                List<RiderRankingEachYearAccumulated> riderRankingEachYearAccumulated = ProcessorUtility.GetRiderPlacementsAccumulated(riderPointsList, i);
                riderRankingEachYearAccumulatedList.AddRange(riderRankingEachYearAccumulated);
                List<NationRankingEachYear> nationRankingEachYear = ProcessorUtility.GetNationsPlacements(nationRankingsThisYear, i);
                nationRankingEachYearList.AddRange(nationRankingEachYear);
                List<NationRankingEachYearAccumulated> nationRankingEachYearAccumulated = ProcessorUtility.GetNationsPlacementsAccumulated(nationPointsList, i);
                nationRankingEachYearAccumulatedList.AddRange(nationRankingEachYearAccumulated);
                List<RiderPoints> ThreeYearSpan = new List<RiderPoints>();
                if (i >= 1888)
                {
                    foreach (RiderRankingEachYear rider in riderRankingEachYearList.Where(r => r.Year >= i - 2 && r.Year <= i))
                    {
                        if (ThreeYearSpan.Any(r => r.RiderId == rider.RiderId))
                        {
                            ThreeYearSpan.FirstOrDefault(r => r.RiderId == rider.RiderId).Points += rider.Points ?? 0;
                        }
                        else
                        {
                            RiderPoints newRider = new RiderPoints();
                            newRider.RiderId = rider.RiderId;
                            newRider.Points = rider.Points ?? 0;
                            ThreeYearSpan.Add(newRider);
                        }
                    }
                    riderRanking3YearSpanList.AddRange(ProcessorUtility.GetRiderPlacements3YearSpan(ThreeYearSpan, i - 2, i));
                }
                

                if ((i + 1) % 10 == 0 || DateTime.Now.Year == i) 
                {
                    riderRankingEachDecades.AddRange(ProcessorUtility.GetRiderPlacementsEachDecade(riderPointsEachDecade, i));
                    riderPointsEachDecade = new List<RiderPoints>();
                }
            }
        }
    }
}
