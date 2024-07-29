using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework.Data
{
    public class AppDbRepository
    {
        public List<Nation> Nations { get; set; }
        public List<NationPoints> NationPoints { get; set; }
        public List<NationRankingEachYear> NationRankingsEachYear { get; set; }
        public List<NationRankingEachYearAccumulated> NationRankingsEachYearAccumulated { get; set; }
        public List<PointSystem> PointSystems { get; set; }
        public List<PreviousNationalities> PreviousNationalities { get; set; }
        public List<Race> Races { get; set; }
        public List<RaceCalendar> RaceCalendars { get; set; }
        public List<RaceClassification> RaceClassifications { get; set; }
        public  List<RaceDate> RaceDates { get; set; }
        public List<Result> Results { get; set; }
        public List<Rider> Riders { get; set; }
        public List<RiderPoints> RiderPoints { get; set; }
        public List<RiderRanking3YearSpan> RiderRankings3YearSpan { get; set; }
        public List<RiderRankingEachDecade> RiderRankingsEachDecade { get; set; }
        public  List<RiderRankingEachYear> RiderRankingsEachYear { get; set; }
        public List<RiderRankingEachYearAccumulated> RiderRankingsEachYearAccumulated { get; set; }
        public List<Team> Teams { get; set; }
    }
}
