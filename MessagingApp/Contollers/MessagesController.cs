using Microsoft.AspNetCore.Mvc;
using MessagingApp.Models;
using Microsoft.EntityFrameworkCore;
using MessagingApp.Data;
using System.Collections.Generic;
using System.Linq;  


[ApiController]
[Route("[controller]")]
public class MessagesController : ControllerBase
{
    private readonly AppDbContext messages;

    public MessagesController(AppDbContext messages)
    {
        this.messages = messages    ;
    }

  
    [HttpGet]
    public IActionResult GetMessages()
    {
        var messages_get = messages.Messages.ToList();
        return Ok(messages_get);
    }

   
    [HttpPost]
    public IActionResult AddMessage( Message newMessage)
    {
        messages.Messages.Add(newMessage);
        messages.SaveChanges();
        return Ok(new { message = "Mesaj adăugat cu succes!" });
    }
}
