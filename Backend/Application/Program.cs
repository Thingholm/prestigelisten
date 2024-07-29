using Application.Processors;
using Application.Services;
using EntityFramework.Data;
using EntityFramework.Models;
using EntityFramework.Utils;
using Microsoft.EntityFrameworkCore;

namespace Application
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string SheetId = "14JS3ioc3jaFTDX2wuHRniE3g3S2yyg1QkfJ7FiNgAE8";
            GoogleSheetsRepository googleSheetsRepository = new GoogleSheetsRepository();
            GoogleSheetsClient googleSheetsClient = new GoogleSheetsClient();
            await googleSheetsClient.InitializeServiceAsync();
            //await googleSheetsRepository.FetchAlltime(googleSheetsClient, SheetId);
            //await googleSheetsRepository.FetchActive(googleSheetsClient, SheetId);
            await googleSheetsRepository.FetchAllResults(googleSheetsClient, SheetId);
            //await googleSheetsRepository.FetchResultsCurrentYear(googleSheetsClient, SheetId);
            AppDbRepository appDbRepository = new AppDbRepository();
            using (AppDbContext dbContext = new AppDbContext())
            {
                appDbRepository.Races = dbContext.Races.ToList();
                appDbRepository.Riders = dbContext.Riders.ToList();
                appDbRepository.Nations = dbContext.Nations.ToList();
                appDbRepository.RaceDates = dbContext.RaceDates.ToList();
                appDbRepository.PointSystems = dbContext.PointSystems.ToList();
                appDbRepository.PreviousNationalities = dbContext.PreviousNationalities.ToList();
                appDbRepository.Results = dbContext.Results.ToList();
            }
        }
    }
}
