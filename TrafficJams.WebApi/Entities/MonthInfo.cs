namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class MonthInfo
    {

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public byte Value { get; set; }
    }
}