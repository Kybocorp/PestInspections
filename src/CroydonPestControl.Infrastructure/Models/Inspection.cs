using CroydonPestControl.Core.Models;
using CroydonPestControl.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CroydonPestControl.Infrastructure.Models
{
    [XmlRoot]
    public class Inspection
    {
        public int InspectionId { get; set; }
        public string InspectionTitle { get; set; }
        public string InspectionSubTitle { get; set; }
        public DateTime InspectionDate { get; set; }
        public string Status { get; set; }
        public string AmPm { get; set; }
        public string FollowUpNotes { get; set; }   
        public Core.ViewModels.Officer Officer { get; set; }
        public Tenant Tenant { get; set; }
        public Address Address { get; set; }
        public bool PestControlForm { get; set; }
        public List<HistoryItem> PreviousInspection { get; set; }
    }
}


