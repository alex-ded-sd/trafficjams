namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class WeekDayInfo
    {

        [XmlAttribute("weekday")]
        public string Weekday { get; set; }

        [XmlText]
        public byte Value { get; set; }
    }
}