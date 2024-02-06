using MongoDB.Bson;

namespace Backend.Models
{
    public class Message
    {
        public ObjectId Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
