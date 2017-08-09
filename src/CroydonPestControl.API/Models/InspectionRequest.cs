using CroydonPestControl.AppService.Models;
using CroydonPestControl.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.API.Models
{
    public class InspectionRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int InspectionId { get; set; }
        public string Status { get; set; }
        public Tenant Tenant { get; set; }
        public Address Address { get; set; }
        public PestControlForm PestControlForm { get; set; }
    }
}