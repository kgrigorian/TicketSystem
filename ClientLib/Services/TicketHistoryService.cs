using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class TicketHistoryService: BaseService
    {
        public TicketHistoryService():base(ServiceConstatns.ServiceUrlPath["ticketHistoryUrlPath"])
        {

        }


        public async Task<Models.TicketHistory> GetTicketHistoryById(int id)
        {
            return await base.GetData<Models.TicketHistory>(id.ToString());

        }

        public async Task<TicketHistory> DeleteTicketHistory(int id)
        {
            return await base.DeleteData<TicketHistory>(id.ToString());
        }

        public async Task<TicketHistory> UpdateTicketHistory(TicketHistory th)
        {
            return await base.PutData<TicketHistory>(th);
        }

        public async Task<TicketHistory> AddTicketHistory(TicketHistory th)
        {
            return await base.PostData<TicketHistory>(th);
        }
    }
}
