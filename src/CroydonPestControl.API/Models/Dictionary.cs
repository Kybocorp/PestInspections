using System.Collections.Generic;
using System.Xml.Serialization;

namespace CroydonPestControl.API.Models
{
    [XmlRoot("Config")]
    public class Dictionary
    {
        [XmlElement("DictionaryList")]
        public List<DictionaryList> DictionaryList { get; set; }
    }
}