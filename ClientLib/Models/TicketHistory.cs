using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.Models
{
    public class TicketHistory
    {

        public int TicketHistoryId { get; set; }
        public DateTime TicketHisDtime { get; set; }
       
        public int TicketId { get; set; }
        
        public int? UserId { get; set; }
        
    }
    



}
