using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.Models
{
    public class Ticket
    {


        public int TicketId { get; set; }
        public DateTime ReportedDtime { get; set; }
        public string Description { get; set; }
        public DateTime? ResolutionDtime { get; set; }
        public int UserId { get; set; }
        public int? AgentId { get; set; }
        public int ProductId { get; set; }
        
    }
    

}
