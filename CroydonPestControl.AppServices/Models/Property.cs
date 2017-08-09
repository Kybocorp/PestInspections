using CroydonPestControl.Core.Models;
using System;
using System.Collections.Generic;

namespace CroydonPestControl.AppServices.Models
{
    public class Property
    {
        public int Id { get; set; }
        public Address Address { get; set; }
        public string AmPm { get; set; }
        public DateTime InspectionStartDate { get; set; }
        public IEnumerable<DateTime> NextInspectionStartDate { get; set; }
    }
}
