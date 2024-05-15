namespace Client.Services
{
    // Author: Mikaela Älgekrans
    public class MessageService
    {
        private string _message;

        public void SendMessage(string message)
        {
            _message = message;
        }

        public string ReceiveMessage()
        {
            var message = _message;
            _message = null; // Deletes message after it's been recieved 
            return message;
        }
    }

}
