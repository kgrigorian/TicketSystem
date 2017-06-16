using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public DateTime ReportedDtime { get; set; }
        public string Description { get; set; }
        //nado li ResolutionDtime?
        public DateTime? ResolutionDtime { get; set; }
        
        //User who created ticket. FK
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        //Ticket assigned to Agent/Admin. FK
        public int? AgentId { get; set; }
        [ForeignKey("AgentId")]
        public virtual User Agent { get; set; }

        //Product FK
        public int ProductId { get; set; }        
        public virtual Product Product { get; set; }
        
        //enum
        public TicketPriority TicketPriority { get; set; }       
        
        //Ticket history
        public virtual List<TicketHistory> TicketHistory { get; set; }  = new List<TicketHistory>();
        //Ticket Replies
        public virtual List<Reply> Replies { get; set; } = new List<Reply>();
    }
}
