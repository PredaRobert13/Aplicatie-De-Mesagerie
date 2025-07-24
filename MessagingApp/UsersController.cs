using Microsoft.AspNetCore.Mvc;
using System;
using MessagingApp.Models;
using System.Collections.Generic;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new List<User>
    {
        new User { Id = 1, Username = "admin", Password = "1234" }
    };

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        var exists = users.Any(u => u.Username == newUser.Username);
        if (exists)
            return BadRequest("Username already taken.");

        newUser.Id = users.Count + 1;
        users.Add(newUser);
        return Ok(new { message = "User registered successfully." });
    }

    [HttpPost("login")]
    public IActionResult Login(User loginUser)
    {
        var user = users.FirstOrDefault(u => u.Username == loginUser.Username && u.Password == loginUser.Password);
        if (user == null)
            return Unauthorized();

        return Ok(new { message = "Login successful." });
    }
}
