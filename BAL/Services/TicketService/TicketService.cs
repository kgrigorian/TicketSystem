using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.TicketService
{
    public class TicketService:ServiceGeneric<TicketDTO, Ticket>, ITicketService
    {
        public TicketService(IFactory<TicketDTO, Ticket> entityFactory, IRepository<Ticket> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
