using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CroydonPestControl.AppServices.Models
{
    public class FollowUpDatesResponse
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingSlot { get; set; }
    }
}
