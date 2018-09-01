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
        [Fact(DisplayName = "Returns correct data from storage")]
        public async Task GetAvailableRegionsTest_MakeServiceCall()
        {
            Mock<GoogleSheetsRegionService> storage = new Mock<GoogleSheetsRegionService>(
                new Mock<IHostingEnvironment>().Object, new Mock<IConfiguration>().Object);
            storage.Setup(sheetsStorage => sheetsStorage.GetAvailableRegionsAsync())
                .ReturnsAsync(() => new List<IList<object>>
                {
                    new object[] {1, "Kyiv"},
                    new object[] {2, "Lviv"},
                });
            AvailableRegionsProvider provider = new AvailableRegionsProvider(storage.Object);
            Dictionary<int, string> result = (Dictionary<int, string>) await provider.GetAvailableRegionsAsync();
            Assert.Equal("Kyiv", result[1]);
            Assert.Equal("Lviv", result[2]);
        }

        [Fact(DisplayName = "Returns correct data from storage twice - make only one service call")]
        public async Task GetAvailableRegionsTest_GetDataFromCache()
        {
            Mock<GoogleSheetsRegionService> storage = new Mock<GoogleSheetsRegionService>(
                new Mock<IHostingEnvironment>().Object, new Mock<IConfiguration>().Object);
            storage.Setup(sheetsStorage => sheetsStorage.GetAvailableRegionsAsync())
                .ReturnsAsync(() => new List<IList<object>>
                {
                    new object[] {1, "Kyiv"},
                    new object[] {2, "Lviv"}
                });
            AvailableRegionsProvider provider = new AvailableRegionsProvider(storage.Object);
            await provider.GetAvailableRegionsAsync();
            Dictionary<int, string> result = (Dictionary<int, string>)await provider.GetAvailableRegionsAsync();
            Assert.Equal("Kyiv", result[1]);
            Assert.Equal("Lviv", result[2]);
            storage.Verify(mock => mock.GetAvailableRegionsAsync(), Times.Once);
        }
    }
}
