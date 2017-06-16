using System;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Enums;

namespace Domain
{
    public class TicketHistory
    {
        public int TicketHistoryId { get; set; }
        public DateTime TicketHisDtime { get; set; }

        //Ticket FK
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }

        //User FK
        
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        //enum
        public TicketStatusCode TicketStatusCode { get; set; }
    }
}
