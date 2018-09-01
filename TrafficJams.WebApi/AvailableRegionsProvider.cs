namespace TrafficJams.WebApi
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// Class, that provides available regions for Yandex API.
    /// </summary>
    public class AvailableRegionsProvider
    {
        private readonly GoogleSheetsRegionService _storage;
        private Dictionary<int, string> _cachedRegions;


        /// <summary>
        /// Initialize new instance of <see cref="AvailableRegionsProvider"/>
        /// </summary>
        /// <param name="storage"></param>
        public AvailableRegionsProvider(GoogleSheetsRegionService storage)
        {
            _storage = storage;
        }

        /// <summary>
        /// Provides available regionsfrom storage
        /// </summary>
        /// <returns>Dictionary, contains region code and region name.</returns>
        public async Task<IDictionary<int, string>> GetAvailableRegionsAsync()
        {
            if (_cachedRegions != null)
                return _cachedRegions;

            IList<IList<object>> rawData = await _storage.GetAvailableRegionsAsync();
            Dictionary<int, string> regions = new Dictionary<int, string>();
            if(rawData != null && rawData.Count > 0)
            {
                foreach(var row in rawData)
                {
                    regions.Add((int)row[0], (string)row[1]);
                }
            }

            _cachedRegions = regions;
            return _cachedRegions;
        }

        
    }
}