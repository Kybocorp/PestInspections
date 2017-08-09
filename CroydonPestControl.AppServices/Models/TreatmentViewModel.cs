using System.Collections.Generic;

namespace CroydonPestControl.AppService.Models
{
    public class TreatmentViewModel
    {
        public int PestId { get; set; }
        public List<int> AreaIds { get; set; }
        public List<int> TreatmentIds { get; set; }
        public int InfestationLevelId { get; set; }
        public int MonitorsUsed { get; set; }
        public int BaitPointsUsed { get; set; }
        public int RefrainUsingFor { get; set; }
    }
}
