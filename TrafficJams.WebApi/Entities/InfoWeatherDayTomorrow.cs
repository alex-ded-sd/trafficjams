namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;


    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoWeatherDayTomorrow
    {

        [XmlElement("temperature")]
        public TemperatureInfo Temperature { get; set; }
    }

    
}