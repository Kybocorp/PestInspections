using System;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.API.Models
{
    public class GetAllInspectionsRequest
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
        public DateTime? InspectionDate { get; set; }
    }
}