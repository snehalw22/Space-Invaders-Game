using System;
using System.Diagnostics;
using System.Xml.Serialization;

namespace SpaceInvaders
{
    [XmlRoot(ElementName = "character")]
    public class Character
    {
        [XmlAttribute(AttributeName = "key")]
        public int key;
        [XmlElement(ElementName = "x")]
        public float x;
        [XmlElement(ElementName = "y")]
        public float y;
        [XmlElement(ElementName = "width")]
        public float width;
        [XmlElement(ElementName = "height")]
        public float height;
    }
}
