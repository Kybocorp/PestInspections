using System;

namespace CroydonPestControl.Infrastructure.Models
{
    public class AddBlockCycleRequest
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
