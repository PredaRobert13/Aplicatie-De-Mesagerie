using Microsoft.AspNetCore.Mvc;
using MessagingApp.Models;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private static List<Message> messages = new List<Message>
    {

     new Message
    {
        Text = "Salut eu sunt Robert si am prieteni tari!"
    },
     new Message
    {
        Text = "Ce mai faci?"
    }
    }; 

    [HttpGet]
    public IActionResult GetMessages()
    { 
        return Ok(messages.Select(m => m.Text));
    }
}