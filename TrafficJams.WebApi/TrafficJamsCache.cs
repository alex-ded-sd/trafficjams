namespace TrafficJams.WebApi
{
    using System;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.Extensions.Caching.Memory;

    /// <summary>
    /// Provides functionality, for caching traffic jams data.
    /// </summary>
    public class TrafficJamsCache
    {
        private readonly IMemoryCache _cache;

        public TrafficJamsCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// TODO summary
        /// </summary>
        /// <param name="regionCode"></param>
        /// <param name="getDataFromServiceAsync"></param>
        public async Task<TrafficJamsResponse> GetOrAddAsync(int regionCode,
        Func<int, Task<TrafficJamsResponse>> getDataFromServiceAsync)
        {
            if(!_cache.TryGetValue(regionCode, out TrafficJamsResponse regionInfo))
            {
                regionInfo = await getDataFromServiceAsync(regionCode);
                var cacheItemOptions = new MemoryCacheEntryOptions { AbsoluteExpiration = DateTime.Now.AddMinutes(1) };
                _cache.Set(regionCode, regionInfo, cacheItemOptions);
            }

            regionInfo.RegionCode = regionCode;
            return regionInfo;
        }
    }
}