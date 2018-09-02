namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DayPart
    {

        [XmlElement("weather_type")]
        public string WeatherType { get; set; }

        [XmlElement("weather_code")]
        public string WeatherCode { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }

        [XmlElement("image-v2")]
        public WeatherInfoImage Imagev2 { get; set; }

        [XmlElement("image-v3")]
        public WeatherInfoImage Imagev3 { get; set; }

        [XmlElement("temperature_from")]
        public TemperatureInfo TemperatureFrom { get; set; }

        [XmlElement("temperature_to")]
        public TemperatureInfo TemperatureTo { get; set; }

        [XmlElement("wind_speed")]
        public double WindSpeed { get; set; }

        [XmlElement("wind_direction")]
        public WindDirection WindDirection { get; set; }

        [XmlElement("dampness")]
        public byte Dampness { get; set; }

        [XmlElement("hectopascal")]
        public ushort Hectopascal { get; set; }


        [XmlElement("torr")]
        public ushort Torr { get; set; }

        [XmlElement("pressure")]
        public ushort Pressure { get; set; }

        [XmlElement("temperature")]
        public TemperatureInfo Temperature { get; set; }

        [XmlElement("timezone")]
        public string TimeZone { get; set; }

        [XmlElement("observation_time")]
        public string ObservationTime { get; set; }

        [XmlElement("observation")]
        public DateTime Observation { get; set; }

        [XmlAttribute("typeid")]
        public byte TypeId { get; set; }

        [XmlAttribute("type")]
        public string Type { get; set; }
    }
}