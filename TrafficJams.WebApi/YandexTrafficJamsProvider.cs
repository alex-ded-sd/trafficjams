namespace TrafficJams.WebApi
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// A service which uses Yandex API for providing information about traffic jams.
    /// </summary>
    public class YandexTrafficJamsProvider : ITrafficJamsProvider
    {
        private readonly AvailableRegionsProvider _provider;

        private const string _yandexApiTemplate =
            "https://export.yandex.com/bar/reginfo.xml?region={regionCode}&bustCache={timeStamp}";

        /// <summary>
        /// Initialize new instance of <see cref="YandexTrafficJamsProvider"/>.
        /// </summary>
        /// <param name="provider"><inheritdoc cref="AvailableRegionsProvider"/>.</param>
        public YandexTrafficJamsProvider(AvailableRegionsProvider provider)
        {
            _provider = provider;
        }

        //public async Task GetTrafficJamsInfoForAllRegionAsync()
        //{
        //    if (Regions == null)
        //        Regions = 
        //}
    }
}