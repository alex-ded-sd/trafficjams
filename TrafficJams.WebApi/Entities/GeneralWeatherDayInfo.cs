namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class GeneralWeatherDayInfo
    {
        [XmlAttribute("date")]
        public DateTime Date { get; set; }

        [XmlElement("day")]
        public WeekDayInfo Day { get; set; }

        [XmlElement("month")]
        public MonthInfo Month { get; set; }

        [XmlElement("year")]
        public ushort Year { get; set; }

        [XmlElement("daytime")]
        public string DayTime { get; set; }
    }
}