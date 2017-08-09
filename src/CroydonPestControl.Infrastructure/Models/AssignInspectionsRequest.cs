using System.Collections.Generic;

namespace CroydonPestControl.Infrastructure.Models
{
    public class AssignInspectionsRequest
    {
        public int OfficerId { get; set; }
        public int AssignedById { get; set; }
        public IEnumerable<int> InspectionIds { get; set; }
    }
}
