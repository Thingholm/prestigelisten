using Application.Services.SheetModels;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GoogleSheetsRepository
    {
        public List<AllTime> AllTime { get; set; } = new List<AllTime>();
        public List<Active> Actives { get; set; } = new List<Active>();
        public List<Results> Results { get; set; } = new List<Results>();

        public async Task FetchAlltime(GoogleSheetsClient client, string SheetId)
        {
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = client.SheetsService.Spreadsheets.Values.Get(SheetId, "All time!A:E");
            ValueRange getResponse = await getRequest.ExecuteAsync();
            AllTime = getResponse.Values.Skip(1).Select(row => row.Count < 5 ? new AllTime() : new AllTime(row)).ToList();
        }

        public async Task FetchActive(GoogleSheetsClient client, string SheetId)
        {
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = client.SheetsService.Spreadsheets.Values.Get(SheetId,"Største aktive!A:G");
            ValueRange getResponse = await getRequest.ExecuteAsync();
            Actives = getResponse.Values.Skip(1).Select(row => row.Count < 7 ? new Active() : new Active(row)).ToList();
        }

        public async Task FetchAllResults(GoogleSheetsClient client, string SheetId)
        {
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = client.SheetsService.Spreadsheets.Values.Get(SheetId, "Resultater!A:ADK");
            ValueRange getResponse = await getRequest.ExecuteAsync();
            Results = getResponse.Values.Select(row => new Results(row)).ToList();
        }
        public async Task FetchResultsCurrentYear(GoogleSheetsClient client, string SheetId)
        {
            SpreadsheetsResource.ValuesResource.GetRequest getRequest = client.SheetsService.Spreadsheets.Values.Get(SheetId, "Resultater!A1:ADK2");
            ValueRange getResponse = await getRequest.ExecuteAsync();
            Results = getResponse.Values.Select(row => new Results(row)).ToList();
        }
    }
}
