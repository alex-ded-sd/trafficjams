namespace TrafficJams.WebApi
{
    using System;
    using System.Net;
    using Entities;

    /// <summary>
    /// TODO summary
    /// </summary>
    public class TrafficJamsResponse
    {
        public bool ResponseStatus { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        //TODO may be redundant
        public Exception Exception { get; set; }

        public Info TrafficJamInformation { get; set; }
    }
}