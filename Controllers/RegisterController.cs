﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


namespace BanHostAPI.Controllers
{
    [Route("api/users/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpGet]
        public IActionResult register(string username, string password)
        {
            if (username == null || password == null) return BadRequest();
            User user = new User();
            user.username = username;
            user.passwordHash = Encrypt.hashPassword(password);
            user.token = Encrypt.tokenGen(user);
            SqliteAccess.SaveUser(user);
            return Ok("Registered user!");
        }
    }
}
