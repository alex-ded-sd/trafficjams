namespace TrafficJams.WebApi
{
    using System.Threading.Tasks;
    using Entities;

    /// <summary>
    /// A contract for services that provides information about traffic jams.
    /// </summary>
    public interface ITrafficJamsProvider
    {
        /// <summary>
        /// Provies traffic jams information for all regions.
        /// </summary>
        /// <returns>Array of tasks, that provides information about async operation of getting traffic jams
        /// for all regions.</returns>
        Task<TrafficJamsResponse[]> GetAllTrafficJamsAsync();

        /// <summary>
        /// Provides traffic jams information for sinle region.
        /// </summary>
        /// <param name="code">Region code.</param>
        /// <returns>Task, that provides information about async operation of getting traffic jams for
        /// single region.</returns>
        Task<TrafficJamsResponse> GetRegionTrafficJamsAsync(int code);
    }
}