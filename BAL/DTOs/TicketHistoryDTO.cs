using Domain;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class TicketHistoryDTO
    {
        public int TicketHistoryId { get; set; }
        public DateTime TicketHisDtime { get; set; }
        //Ticket FK
        public int TicketId { get; set; }
        //User FK
        public int? UserId { get; set; }
        //enum
        public TicketStatusCode TicketStatusCode { get; set; }
    }
}
