﻿using System;

namespace CroydonPestControl.AppServices.Models
{
    public class BlockCycle
    {
        public int BlockCycleId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int StatusId { get; set; }
    }
}
