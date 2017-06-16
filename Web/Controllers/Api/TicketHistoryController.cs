using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.TicketHistoryService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class TicketHistoryController : ApiController
    {
        private readonly ITicketHistoryService _ticketHistoryService;

        public TicketHistoryController(ITicketHistoryService ticketHistoryService)
        {
            _ticketHistoryService = ticketHistoryService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_ticketHistoryService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var ticketHistory = _ticketHistoryService.GetById(id);
            if (null == ticketHistory)
            {
                return NotFound();
            }
            return Ok(ticketHistory);
        }
        [HttpPost]
        public IHttpActionResult Post([FromBody] TicketHistoryDTO ticketHistory)
        {
            var ticketHistoryAdded = _ticketHistoryService.Add(ticketHistory);
            return CreatedAtRoute("DefaultApi", new { id = ticketHistory.TicketHistoryId }, ticketHistoryAdded);
        }
        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var ticketHistory = _ticketHistoryService.GetById(id);
            if (null == ticketHistory)
            {
                return NotFound();
            }
            ticketHistory = _ticketHistoryService.Delete(id);
            return Ok(ticketHistory);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] TicketHistoryDTO ticketHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _ticketHistoryService.Update(ticketHistory);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
