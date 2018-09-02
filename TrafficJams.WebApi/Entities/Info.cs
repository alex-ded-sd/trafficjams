namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot("info", Namespace = "", IsNullable = false)]
    public class Info
    {
        [XmlElement("region")]
        public InfoRegion Region { get; set; }

        [XmlElement("traffic")]
        public InfoTraffic Traffic { get; set; }

        [XmlElement("weather")]
        public InfoWeather Weather { get; set; }

        [XmlAttribute("lang")]
        public string Lang { get; set; }
    }
}