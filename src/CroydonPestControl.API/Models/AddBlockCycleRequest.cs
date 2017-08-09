using System;
using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.API.Models
{
    public class AddBlockCycleRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
