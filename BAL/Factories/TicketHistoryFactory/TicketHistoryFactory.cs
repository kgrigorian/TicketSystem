using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;
using Domain.Enums;

namespace BAL.Factories
{
    public class TicketHistoryFactory : ITicketHistoryFactory

    {
    public TicketHistoryDTO Create(TicketHistory ticketHistory)
    {
        return new TicketHistoryDTO()
        {
            TicketHistoryId = ticketHistory.TicketHistoryId,
            TicketHisDtime = ticketHistory.TicketHisDtime,
            TicketId = ticketHistory.TicketId,
            UserId = ticketHistory.UserId,
            TicketStatusCode = ticketHistory.TicketStatusCode
    };
    }
        public TicketHistory Create(TicketHistoryDTO dto)
        {
            return new TicketHistory()
            {
                TicketHistoryId = dto.TicketHistoryId,
                TicketHisDtime = dto.TicketHisDtime,
                TicketId = dto.TicketId,
                UserId = dto.UserId,
                TicketStatusCode = dto.TicketStatusCode
            };
        }

    }
}
