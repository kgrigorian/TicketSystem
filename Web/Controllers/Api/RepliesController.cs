using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.ReplyService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class RepliesController : ApiController
    {
        private readonly IReplyService _replyService;

        public RepliesController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_replyService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var reply = _replyService.GetById(id);
            if (null == reply)
            {
                return NotFound();
            }
            return Ok(reply);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] ReplyDTO reply)
        {
            var replyAdded = _replyService.Add(reply);
            return CreatedAtRoute("DefaultApi", new { id = reply.ReplyId }, replyAdded);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var reply = _replyService.GetById(id);
            if (null == reply)
            {
                return NotFound();
            }
            reply = _replyService.Delete(id);
            return Ok(reply);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] ReplyDTO reply)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _replyService.Update(reply);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
