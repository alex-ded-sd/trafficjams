namespace TrafficJams.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Class, that provides available regions for Yandex API.
    /// </summary>
    public class AvailableRegionsProvider
    {
        //TODO code smell
        private readonly GoogleSheetsRegionService _storage;
        private static Dictionary<int, string> _cachedRegions;
        private static readonly SemaphoreSlim _lockSemaphoreSlim = new SemaphoreSlim(1, 1);


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
            await _lockSemaphoreSlim.WaitAsync();
            if (_cachedRegions == null)
            {
                IList<IList<object>> rawData = await _storage.GetAvailableRegionsAsync();
                Dictionary<int, string> regions = new Dictionary<int, string>();
                if(rawData != null && rawData.Count > 0)
                {
                    foreach(IList<object> row in rawData)
                    {
                        if(int.TryParse(row[0].ToString(), out int key) && !regions.ContainsKey(key))
                            regions.Add(key, row[1].ToString());
                    }
                }
                _cachedRegions = regions;
            }
            
            _lockSemaphoreSlim.Release();
            return _cachedRegions;
        }

        
    }
}