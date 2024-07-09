using EntityFramework.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GoogleSheetsClient
    {
        private GoogleCredential credential;
        public SheetsService SheetsService { get; private set; }
        public string ApplicationName = "prestigelisten";

        private async Task authorizeAsync()
        {
            using (var stream = new FileStream("Application/bin/Debug/net8.0/ClientSecrets.json", FileMode.Open, FileAccess.Read))
            {
                credential = GoogleCredential.FromStream(stream).CreateScoped(new string[] { SheetsService.Scope.Spreadsheets });
            }
        }

        public async Task InitializeServiceAsync()
        {
            await authorizeAsync();
            SheetsService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName
            });
        }
    }
}
