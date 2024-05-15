using Client.Models;

namespace Client.Services
{
    // Author: Mikaela Älgekrans
    public class MessageService
    {
        private Message _message;

        public void SendMessage(Message message)
        {
            _message = message;
        }

        public Message ReceiveMessage()
        {
            var message = _message;
            _message = null; // Deletes message after it's been recieved 
            return message;
        }
    }
}
