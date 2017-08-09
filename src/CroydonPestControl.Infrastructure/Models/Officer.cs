namespace CroydonPestControl.Infrastructure.Models
{
    public class Officer
    {
        public int OfficerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficerDisplayName { get; set; }
        public int TeamId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
