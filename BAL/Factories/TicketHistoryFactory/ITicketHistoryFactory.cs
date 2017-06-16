using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;

namespace BAL.Factories
{
    public interface ITicketHistoryFactory : IFactory<TicketHistoryDTO, TicketHistory>
    {
        
    }
}
