using Microsoft.AspNetCore.Mvc;
using Backend.Models; // Assuming Message class is defined in this namespace
using Microsoft.EntityFrameworkCore; // Assuming DbContext is defined in this namespace

namespace Backend.Controllers
{
    public class MessagesController : Controller
    {
        private readonly DbContext _context;

        public MessagesController(DbContext context)
        {
            _context = context;
        }

        [HttpPost("send")]
        public IActionResult SendMessage([FromBody] Message message)
        {
            try
            {
                // Fügen Sie die aktuelle Zeit hinzu
                message.Timestamp = DateTime.Now;

                // Fügen Sie die Nachricht zur Datenbank hinzu
                _context.Set<Message>().Add(message);
                _context.SaveChanges();

                return Ok("Message sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error sending message: {ex.Message}");
            }
        }
    }
}
