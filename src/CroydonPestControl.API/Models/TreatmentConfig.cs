using System.Collections.Generic;
using System.Xml.Serialization;

namespace CroydonPestControl.API.Models
{
    [XmlRoot]
    public class TreatmentConfig
    {
        public List<Treatment> Treatments { get; set; }
        public List<PestTreatment> PestTreatmentRelations { get; set; }
    }
}
