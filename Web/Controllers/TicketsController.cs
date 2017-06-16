using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClientLib.Models;
using ClientLib.Services;

namespace Web.Controllers
{
    public class TicketsController : Controller
    {
        private static ClientLib.Services.TicketService _ticketService = new TicketService();

        // GET: Tickets
        public async  Task<ActionResult> Index()
        {
            List<Ticket> tickets = await _ticketService.GetAllTickets();
            return View(tickets);
        }

        // GET: Tickets/Details/5
        public async Task <ActionResult> Details(int id)
        {
            Ticket ticket = await _ticketService.GetTicketById(id);
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                Ticket ticket = convertToTicket(collection);

                await _ticketService.AddTicket(ticket);            
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Ticket ticket = await _ticketService.GetTicketById(id);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                Ticket ticket = convertToTicket(collection);
                await _ticketService.UpdateTicket(ticket);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Tickets/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Ticket ticket = await _ticketService.GetTicketById(id);
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost]
        public async  Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                await _ticketService.DeleteTicket(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private Ticket convertToTicket(FormCollection collection)
        {
            return new Ticket
            {
                TicketId = Convert.ToInt32(collection["TicketId"]),
                Description = collection["Description"],
                UserId = Convert.ToInt32(collection["UserId"]),
                AgentId = Convert.ToInt32(collection["AgentId"]),
                ProductId = Convert.ToInt32(collection["ProductId"])
            };
        }

    }
}
