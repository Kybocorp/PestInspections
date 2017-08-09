using System.Collections.Generic;
using System.Xml.Serialization;

namespace CroydonPestControl.API.Models
{
   
    public class DictionaryItems
    {
        [XmlElement("DictionaryItem")]
        public List<DictionaryItem> DictionaryItem { get; set; }
    }
}
