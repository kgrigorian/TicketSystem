using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.UserService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class UsersController : ApiController
    {
    //    private readonly IUserService _userService;

    //    public UsersController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }

    //    [HttpGet]
    //    public IHttpActionResult GetAll()
    //    {
    //        return Ok(_userService.GetAllUsers());
    //    }

    //    public IHttpActionResult Get(int id)
    //    {
    //        var user = _userService.GetUserById(id);
    //        if (user == null) return NotFound();
    //        return Ok(user);
    //    }
    //    [HttpPost]
    //    public IHttpActionResult Post([FromBody] UserDTO user)
    //    {
    //        var userAdded = _userService.AddNewUser(user);
    //        return CreatedAtRoute("DefaultApi", new {id = user.UserId}, userAdded);
    //    }
    }
}
