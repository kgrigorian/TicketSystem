using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.TicketHistoryService
{
    public class TicketHistoryService : ServiceGeneric<TicketHistoryDTO, TicketHistory>, ITicketHistoryService
    {
        public TicketHistoryService(IFactory<TicketHistoryDTO, TicketHistory> entityFactory, IRepository<TicketHistory> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
