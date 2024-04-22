namespace Client.Models
{
    public class APIKey
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string Domain { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
