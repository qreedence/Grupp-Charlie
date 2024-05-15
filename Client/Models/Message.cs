namespace Client.Models
{
    // Author: Mikaela Älgekrans
    public class Message
    {
        public string Text { get; set; }
        public MessageType Type { get; set; }
    }

    public enum MessageType
    {
        Success,
        Error
    }
}
