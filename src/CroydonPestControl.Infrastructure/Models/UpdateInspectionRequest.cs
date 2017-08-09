namespace CroydonPestControl.Infrastructure.Models
{
    public class UpdateInspectionRequest
    {
        public int InspectionId { get; set; }
        public int NoAccessId { get; set; }
        public int VisitTypeId { get; set; }
        public FollowUp FollowUp { get; set; }
    }
}
