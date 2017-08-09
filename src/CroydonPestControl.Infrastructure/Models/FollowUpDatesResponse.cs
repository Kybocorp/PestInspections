using System;

namespace CroydonPestControl.Infrastructure.Models
{
    public class FollowUpDatesResponse
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingSlot { get; set; }
    }
}
