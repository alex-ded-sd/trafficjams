namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoWeather
    {

        [XmlElement("source")]
        public string Source { get; set; }

        [XmlElement("day")]
        public InfoWeatherDay Day { get; set; }

        [XmlElement("url")]
        public InfoWeatherUrl Url { get; set; }

        [XmlAttribute("climate")]
        public byte Climate { get; set; }

        [XmlAttribute("region")]
        public byte Region { get; set; }
    }
}