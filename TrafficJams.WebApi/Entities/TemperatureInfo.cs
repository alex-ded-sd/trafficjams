namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class TemperatureInfo
    {

        [XmlAttribute("class_name")]
        public string ClassName { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

        [XmlText]
        public sbyte Value { get; set; }
    }
}