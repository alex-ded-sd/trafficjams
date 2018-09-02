namespace TrafficJams.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;
    using Entities;
    using Google.Apis.Http;
    using IHttpClientFactory = System.Net.Http.IHttpClientFactory;

    /// <summary>
    /// A service which uses Yandex API for providing information about traffic jams.
    /// </summary>
    public class YandexTrafficJamsProvider : ITrafficJamsProvider
    {
        private readonly AvailableRegionsProvider _provider;
        private readonly IHttpClientFactory _clientFactory;

        private const string _yandexApiTemplate =
            "https://export.yandex.com/bar/reginfo.xml?region={0}&bustCache={1}";

        /// <summary>
        /// Initialize new instance of <see cref="YandexTrafficJamsProvider"/>.
        /// </summary>
        /// <param name="provider"><inheritdoc cref="AvailableRegionsProvider"/>.</param>
        /// <param name="clientFactory"><inheritdoc cref="HttpClientFactory"/></param>
        public YandexTrafficJamsProvider(AvailableRegionsProvider provider, IHttpClientFactory clientFactory)
        {
            _provider = provider;
            _clientFactory = clientFactory;
        }

        private Info DeserializeXml(string xmlContent)
        {
            if (!string.IsNullOrEmpty(xmlContent))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Info), typeof(Info).GetNestedTypes());
                using(MemoryStream memStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlContent)))
                {
                    return (Info)xmlSerializer.Deserialize(memStream);
                }
            }

            //TODO code smell
            return null;
        }

        private async Task<TrafficJamsResponse> GetDataForSingleRegionAsync(HttpClient httpClient, string uri)
        {
            TrafficJamsResponse trafficJamsResponse = new TrafficJamsResponse();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                trafficJamsResponse = new TrafficJamsResponse {HttpStatusCode = response.StatusCode};
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    Info regionInfo = DeserializeXml(responseString);
                    if(regionInfo != null)
                        trafficJamsResponse.ResponseStatus = true;
                    trafficJamsResponse.TrafficJamInformation = regionInfo;
                }
            }
            catch (Exception exception)
            {
                trafficJamsResponse.ResponseStatus = false;
                trafficJamsResponse.Exception = exception;
            }

            return trafficJamsResponse;
        }

        public async Task<TrafficJamsResponse[]> GetAllTrafficJamsAsync()
        {
            IDictionary<int, string> regions = await _provider.GetAvailableRegionsAsync();
            var httpClient = _clientFactory.CreateClient();
            Task<TrafficJamsResponse>[] regionsDataTasks = regions
                .Select(region => GetDataForSingleRegionAsync(httpClient,
                    string.Format(_yandexApiTemplate, region.Key, 1000))).ToArray();
            return await Task.WhenAll(regionsDataTasks);
        }

        public async Task<TrafficJamsResponse> GetRegionTrafficJamsAsync(int code)
        {
            IDictionary<int, string> regions = await _provider.GetAvailableRegionsAsync();
            if (regions.Keys.Contains(code))
            {
                var httpClient = _clientFactory.CreateClient();
                return await GetDataForSingleRegionAsync(httpClient, string.Format(_yandexApiTemplate, code, 1000));
            }

            return new TrafficJamsResponse();
        }
    }
}