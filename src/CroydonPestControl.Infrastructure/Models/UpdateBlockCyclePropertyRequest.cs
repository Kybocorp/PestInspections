using System;

namespace CroydonPestControl.Infrastructure.Models
{
    public class UpdateBlockCyclePropertyRequest
    {
        public int BlockCycleId { get; set; }
        public int PropertyId { get; set; }
        public int StatusId { get; set; }
        public string AmPm { get; set; }
        public DateTime NextInspectionDate { get; set; }
        public string Comments { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
