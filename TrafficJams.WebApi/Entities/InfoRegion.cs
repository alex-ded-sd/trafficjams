﻿namespace TrafficJams.WebApi.Entities
{
    using System;
    using System.ComponentModel;
    using System.Xml.Serialization;

    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class InfoRegion
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlAttribute("id")]
        public byte Id { get; set; }

        [XmlAttribute("zoom")]
        public byte Zoom { get; set; }

        [XmlAttribute("lat")]
        public decimal Latitude { get; set; }

        [XmlAttribute("lon")]
        public decimal Longitude { get; set; }
    }
}