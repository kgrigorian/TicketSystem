using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.TicketService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class TicketsController : ApiController
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_ticketService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var ticket = _ticketService.GetById(id);
            if (null == ticket)
            {
                return NotFound();
            }
            return Ok(ticket);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] TicketDTO ticket)
        {
            var ticketAdded = _ticketService.Add(ticket);
            return CreatedAtRoute("DefaultApi", new { id = ticket.TicketId }, ticketAdded);
        }
        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var ticket = _ticketService.GetById(id);
            if (null == ticket)
            {
                return NotFound();
            }
            ticket = _ticketService.Delete(id);
            return Ok(ticket);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] TicketDTO ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ticketService.Update(ticket);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
