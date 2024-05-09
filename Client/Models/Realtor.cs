namespace Client.Models
{
    public class Realtor
    {
        public string Id { get; set; }
        public Agency? Agency { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Avatar { get; set; }
        public string? PhoneNumber { get; set; }

        public bool? EmailConfirmed { get; set; }
        //public string? PasswordHash { get; set; }
    }
}
