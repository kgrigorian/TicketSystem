using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
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
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_userService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            if (null == user)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] UserDTO user)
        {
            var userAdded = _userService.Add(user);
            return CreatedAtRoute("DefaultApi", new { id = user.UserId }, userAdded);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var user = _userService.GetById(id);
            if (null == user)
            {
                return NotFound();
            }
            user = _userService.Delete(id);
            return Ok(user);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _userService.Update(user);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
