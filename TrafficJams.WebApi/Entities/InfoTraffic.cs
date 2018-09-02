namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoTraffic
    {
        [XmlElement("region")]
        public InfoTrafficRegion InfoTrafficRegion { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlAttribute("region")]
        public byte Region { get; set; }

        [XmlAttribute("zoom")]
        public byte Zoom { get; set; }

        [XmlAttribute("lat")]
        public decimal Latiude { get; set; }

        [XmlAttribute("lon")]
        public decimal Longitude { get; set; }
    }
}