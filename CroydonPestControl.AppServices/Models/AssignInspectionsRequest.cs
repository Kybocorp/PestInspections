using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.AppServices.Models
{
    public class AssignInspectionsRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int OfficerId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int AssignedById { get; set; }     
        [Required]
        public IEnumerable<int> InspectionIds { get; set; }
    }
}
