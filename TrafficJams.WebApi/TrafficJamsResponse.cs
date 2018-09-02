namespace TrafficJams.WebApi
{
    using System;
    using System.Net;
    using Entities;

    /// <summary>
    /// Traffic jams response class, that contains information about <see cref="HttpStatusCode"/>, response status and
    /// traffic jams data.
    /// </summary>
    public class TrafficJamsResponse
    {
        public int RegionCode { get; set; }

        public bool ResponseStatus { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        //TODO may be redundant
        public Exception Exception { get; set; }

        public Info Data { get; set; }
    }
}