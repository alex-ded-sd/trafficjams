namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoWeatherDay
    {

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("country")]
        public string Country { get; set; }

        [XmlElement("time_zone")]
        public string TimeZone { get; set; }

        [XmlElement("summer-time")]
        public int SummerTime { get; set; }

        [XmlElement("sun_rise")]
        //TODO datetime
        public string SunRise { get; set; }

        [XmlElement("sunset")]
        //TODO datetime
        public string SunSet { get; set; }

        [XmlElement("daytime")]
        public string DayTime { get; set; }

        [XmlElement("date")]
        public GeneralWeatherDayInfo Date { get; set; }

        [XmlElement("day_part")]
        public DayPart[] DayPart { get; set; }

        [XmlElement("night_short")]
        public InfoWeatherDayNightShort NightShort { get; set; }

        [XmlElement("tomorrow")]
        public InfoWeatherDayTomorrow Tomorrow { get; set; }

        [XmlText]
        public string[] Text { get; set; }
    }
}