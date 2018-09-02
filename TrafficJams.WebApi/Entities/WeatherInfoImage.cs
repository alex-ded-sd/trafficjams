namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class WeatherInfoImage
    {

        [XmlAttribute("size")]
        public string Size { get; set; }

        /// <remarks/>
        public string Value { get; set; }
    }
}