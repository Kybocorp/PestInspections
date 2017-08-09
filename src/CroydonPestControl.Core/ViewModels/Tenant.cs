using System.ComponentModel.DataAnnotations;

namespace CroydonPestControl.Core.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string TenantDisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string Telephone { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsDangerous { get; set; }
        public bool IsNewTenant { get; set; }
    }
}
