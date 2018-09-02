namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoWeatherUrl
    {

        [XmlAttribute("slug")]
        public string Slug { get; set; }

        [XmlText]
        public string Value { get; set; }
    }
}
