using System;

namespace MessagingApp.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; } 
        public string Sender { get; set; } 
        public string Receiver { get; set; } 
        public DateTime Timestamp { get; set; }
    }
}
