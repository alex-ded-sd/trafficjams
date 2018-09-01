namespace TrafficJams.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Services;
    using Google.Apis.Sheets.v4;
    using Google.Apis.Sheets.v4.Data;
    using Google.Apis.Util.Store;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;

    /// <summary>
    /// Provides information about available regions for Yandex traffic jams API from Google sheets.
    /// </summary>
    public class GoogleSheetsRegionService
    {
        private static readonly IEnumerable<string> _scopes = new[] { SheetsService.Scope.SpreadsheetsReadonly };
        private static readonly SemaphoreSlim _lockSemaphoreSlim = new SemaphoreSlim(1, 1);
        private static UserCredential _credential;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initialize new instance of <see cref="GoogleSheetsRegionService"/>.
        /// </summary>
        /// <param name="hostingEnvironment"><inheritdoc cref="IHostingEnvironment"/></param>
        /// <param name="configuration"><inheritdoc cref="IConfiguration"/></param>
        public GoogleSheetsRegionService(IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        private async Task<UserCredential> GetGoogleApiCredentialsAsync(string filePath)
        {
            UserCredential credential;
            using(FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                string credPath = Path.Combine(_hostingEnvironment.ContentRootPath, "token.json");
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    _scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true));
            }

            return credential;
        }

        private IList<IList<object>> GetRegions()
        {
            SheetsService service = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = _credential,
                ApplicationName = "TrafficJams"
            });
            string spreadsheetId = "1AhemqFP2lZ4ifcXGmArOydA3w24Yd7LdQ3KZveN-JR4";
            string range = "Class Data!A1:B";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                service.Spreadsheets.Values.Get(spreadsheetId, range);
            ValueRange response = request.Execute();
            return response.Values;
        }

        /// <summary>
        /// Gets data from google sheet with Id=1AhemqFP2lZ4ifcXGmArOydA3w24Yd7LdQ3KZveN-JR4.
        /// </summary>
        /// <returns>Raw data contains information about region name and region code</returns>
        public virtual async Task<IList<IList<Object>>> GetAvailableRegionsAsync()
        {
            string regionFileCedentialsName = _configuration["regionsFileCredentials"];
            if(string.IsNullOrEmpty(regionFileCedentialsName))
                throw new ArgumentNullException(nameof(regionFileCedentialsName));

            string filePath = Path.Combine(_hostingEnvironment.ContentRootPath, regionFileCedentialsName);
            await _lockSemaphoreSlim.WaitAsync();
            if(_credential == null)
                _credential = await GetGoogleApiCredentialsAsync(filePath);
            _lockSemaphoreSlim.Release();
            IList<IList<object>> regions = GetRegions();
            return regions;
        }
    }
}