namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoTrafficRegionHint
    {
        [XmlAttribute("lang")]
        public string Lang { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}