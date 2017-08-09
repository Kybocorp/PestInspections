namespace CroydonPestControl.Core.Models
{
    public class Address
    {
        public int PropertyId { get; set; }
        public string HouseName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}