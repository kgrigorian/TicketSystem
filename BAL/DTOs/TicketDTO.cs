using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;

namespace BAL.DTOs
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public DateTime ReportedDtime { get; set; }
        public string Description { get; set; }
        public DateTime? ResolutionDtime { get; set; }
        public int UserId { get; set;}
        public int? AgentId { get; set; }
        public int ProductId { get; set; }
        public int TicketPriority { get; set; }
    }
}
