using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.API.Models
{
    public class FollowUpDatesRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int InspectionId { get; set; }
        [Required]
        public IEnumerable<int> Pests { get; set; }
    }
}
