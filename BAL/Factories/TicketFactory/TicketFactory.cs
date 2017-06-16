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
    public class TicketFactory : ITicketFactory

    {
    public TicketDTO Create(Ticket ticket)
    {
        return new TicketDTO()
        {
            TicketId = ticket.TicketId,
            Description = ticket.Description,
            ReportedDtime = ticket.ReportedDtime,
            ResolutionDtime = ticket.ResolutionDtime,
            UserId = ticket.UserId,
            AgentId = ticket.AgentId,
            ProductId = ticket.ProductId,
            TicketPriority = (int)ticket.TicketPriority
        };
    }
        public Ticket Create(TicketDTO dto)
        {
            return new Ticket()
            {
                TicketId = dto.TicketId,
                ReportedDtime = DateTime.Now,
                Description = dto.Description,
                ResolutionDtime = dto.ResolutionDtime,
                UserId = dto.UserId,//?
                AgentId = dto.AgentId,
                ProductId = dto.ProductId,
                TicketPriority = (TicketPriority)dto.TicketPriority
            };
        }

    }
}
