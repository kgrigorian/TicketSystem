using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface ITicketHistoryRepository : IRepository<TicketHistory>
    {
        //siin tuleb custom meetodid kirja panna, esimesena siis kirjuta vastavas interfaces ja teisena siis vastavas repositories implementatsioon.
           
        List<TicketHistory> GetOrderedRecords(int recordLimit, bool orderByTicketStatusCode = true);
    }
}
