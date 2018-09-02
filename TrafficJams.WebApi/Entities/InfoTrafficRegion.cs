namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoTrafficRegion
    {
        [XmlAttribute("id")]
        public byte Id { get; set; }

        [XmlElement("length")]
        public decimal Length { get; set; }

        [XmlElement("level")]
        public byte Level { get; set; }

        [XmlElement("icon")]
        public string Icon { get; set; }

        [XmlElement("timestamp")]
        public uint Timestamp { get; set; }

        [XmlElement("time")]
        public string Time { get; set; }

        [XmlElement("hint")]
        public InfoTrafficRegionHint[] Hint { get; set; }

        [XmlElement("tend")]
        public byte Tend { get; set; }

        [XmlElement("url")]
        public string Url { get; set; }
    }
}