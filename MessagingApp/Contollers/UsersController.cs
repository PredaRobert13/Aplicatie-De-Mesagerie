using Microsoft.AspNetCore.Mvc;
using System;
using MessagingApp.Models;
using System.Collections.Generic;
using System.Linq;using MessagingApp.Data;


[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
   private readonly AppDbContext user;
   public UsersController(AppDbContext user)
    {
        this.user = user;
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        var exists = user.Users.Any(u => u.Username == newUser.Username);
        if (exists)
            return BadRequest("Username already taken.");
        user.Users.Add(newUser);
        user.SaveChanges();
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(User loginUser)
    {
        var user_login = user.Users.FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
        if (user_login == null)
            return Unauthorized();

        return Ok(new { message = "Login successful." });
    }
    [HttpGet("all")]
    public ActionResult<List<string>> GetUsersnames()
    {
        var username = user.Users.Select(u => u.Username).ToList();
        return Ok(username);
    }
    
}
