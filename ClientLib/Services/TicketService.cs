using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class TicketService: BaseService
    {
        public TicketService():base(ServiceConstatns.ServiceUrlPath["ticketsUrlPath"])
        {

        }

        public async Task<List<Models.Ticket>> GetAllTickets()
        {
            return await base.GetData<List<Models.Ticket>>("");
        }


        public async Task<Models.Ticket> GetTicketById(int id)
        {
            return await base.GetData<Models.Ticket>(id.ToString());
        }

        public async Task<Ticket> DeleteTicket(int id)
        {
            return await base.DeleteData<Ticket>(id.ToString());
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
            return await base.PutData<Ticket>(ticket);
        }

        public async Task<Ticket> AddTicket(Ticket ticket)
        {
            return await base.PostData<Ticket>(ticket);
        }
    }
}
