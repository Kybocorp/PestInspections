using System;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.AppServices.Models
{
    public class UpdateBlockCyclePropertyRequest
    {
        [Required]
        public int BlockCycleId { get; set; }
        [Required]
        public int PropertyId { get; set; }
        public int StatusId { get; set; }
        public string AmPm { get; set; }
        public DateTime NextInspectionDate { get; set; }
        public string Comments { get; set; }
        public int LastUpdatedBy { get; set; }
    }
}
