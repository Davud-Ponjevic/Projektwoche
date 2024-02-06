using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    public class MessagesController
    {
        private object _context;

        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] Message message)
        {
            try
            {
                // Fügen Sie die aktuelle Zeit hinzu
                message.Timestamp = DateTime.Now;

                // Fügen Sie die Nachricht zur Datenbank hinzu
                _context.Messages.InsertOne(message);

                return Ok("Message sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequestResult($"Error sending message: {ex.Message}");
            }
        }


    }
}
