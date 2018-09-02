namespace TrafficJams.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/trafficjams")]
    public class TrafficJamsController : ControllerBase
    {
        private readonly ITrafficJamsProvider _provider;

        public TrafficJamsController(ITrafficJamsProvider provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public async Task<TrafficJamsResponse[]> Get()
        {
            TrafficJamsResponse[] result = await _provider.GetAllTrafficJamsAsync();
            return result;
        }

        [Route("{code:int}")]
        [HttpGet]
        public async Task<TrafficJamsResponse> Get(int code)
        {
            TrafficJamsResponse result = await _provider.GetRegionTrafficJamsAsync(code);
            return result;
        }
    }
}