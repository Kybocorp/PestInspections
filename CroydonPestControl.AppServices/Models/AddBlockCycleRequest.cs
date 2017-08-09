using System;

namespace CroydonPestControl.AppServices.Models
{
    public class AddBlockCycleRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
