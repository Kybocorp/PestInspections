using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.API.Models
{
    public class UpdateInspectionRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int InspectionId { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int NoAccessId { get; set; }
        public int VisitTypeId { get; set; }
        public FollowUp FollowUp { get; set; }
    }
}
