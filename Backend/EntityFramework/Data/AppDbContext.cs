using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Models;

namespace EntityFramework.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Nation> Nations { get; set; }
        public DbSet<NationPoints> NationPoints { get; set; }
        public DbSet<NationRankingEachYear> NationRankingsEachYear { get; set; }
        public DbSet<NationRankingEachYearAccumulated> NationRankingsEachYearAccumulated { get; set; }
        public DbSet<PointSystem> PointSystems { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceCalendar> RaceCalendars { get; set; }
        public DbSet<RaceClassification> RaceClassifications { get; set; }
        public DbSet<RaceDate> RaceDates { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Rider> Riders { get; set; }
        public DbSet<RiderPoints> RiderPoints { get; set; }
        public DbSet<RiderRanking3YearSpan> RiderRankings3YearSpan { get; set; }
        public DbSet<RiderRankingEachDecade> RiderRankingsEachDecade { get; set; }
        public DbSet<RiderRankingEachYear> RiderRankingsEachYear { get; set; }
        public DbSet<RiderRankingEachYearAccumulated> RiderRankingsEachYearAccumulated { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("SUPABASE_CONNECTION_STRING")).EnableSensitiveDataLogging().LogTo(Console.WriteLine);
        }
    }
}
