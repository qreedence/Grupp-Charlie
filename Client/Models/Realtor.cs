namespace Client.Models
{
    public class Realtor
    {
        public int RealtorId { get; set; }
        public Agency? Agency { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Phonenumber { get; set; }
        public string Avatar { get; set; }
    }
}
