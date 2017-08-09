using System;
using System.Collections.Generic;

namespace CroydonPestControl.AppService.Models
{
    public class PestControlForm
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int NoAccess { get; set; }
        public int? InsectMonitorsFound { get; set; }
        public int? BaitPointsFound { get; set; }
        public List<TreatmentViewModel> Treatments { get; set; }
        public int HygieneLevelId { get; set; }
        public List<int> RiskAssessmentIds { get; set; }
        public List<int> StandardCommentsIds { get; set; }
        public List<int> HygieneCommentsIds  { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        public bool JobClosed { get; set; }
        public int VisitTypeId { get; set; }
        public int? FollowUpDate { get; set; }
        public string FollowUpNotes { get; set; }
        public string Notes { get; set; }
        public byte[] TenantSignature  { get; set; }
        public byte[] UserSignature { get; set; }
        public List<byte[]> EvidenceImages { get; set; }
    }
}
