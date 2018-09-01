namespace TrafficJams.WebApi.Tests
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Moq;
    using Xunit;

    public class AvailableRegionsProviderTests
    {
        private readonly Mock<GoogleSheetsRegionService> _regionService;
        public AvailableRegionsProviderTests()
        {
            _regionService = new Mock<GoogleSheetsRegionService>(
                new Mock<IHostingEnvironment>().Object, new Mock<IConfiguration>().Object);
            _regionService.Setup(sheetsStorage => sheetsStorage.GetAvailableRegionsAsync())
                .ReturnsAsync(() => new List<IList<object>>
                {
                    new object[] {1, "Kyiv"},
                    new object[] {2, "Lviv"},
                });
        }

        [Fact(DisplayName = "Returns correct data from _regionService")]
        public async Task GetAvailableRegionsTest_MakeServiceCall()
        {
            AvailableRegionsProvider provider = new AvailableRegionsProvider(_regionService.Object);
            Dictionary<int, string> result = (Dictionary<int, string>) await provider.GetAvailableRegionsAsync();
            Assert.Equal("Kyiv", result[1]);
            Assert.Equal("Lviv", result[2]);
        }

        [Fact(DisplayName = "Returns correct data from _regionService twice - make only one service call")]
        public async Task GetAvailableRegionsTest_GetDataFromCache()
        {
            AvailableRegionsProvider provider = new AvailableRegionsProvider(_regionService.Object);
            await provider.GetAvailableRegionsAsync();
            Dictionary<int, string> result = (Dictionary<int, string>)await provider.GetAvailableRegionsAsync();
            Assert.Equal("Kyiv", result[1]);
            Assert.Equal("Lviv", result[2]);
            _regionService.Verify(mock => mock.GetAvailableRegionsAsync(), Times.Once);
        }
    }
}
