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
        public int Climate { get; set; }

        [XmlAttribute("region")]
        public int Region { get; set; }
    }
}