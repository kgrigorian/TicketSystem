using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.Models
{
    public class Reply
    {

        public int ReplyId { get; set; }

        public DateTime ReplyDtime { get; set; }
        public string ReplyText { get; set; }
     
        public int? UserId { get; set; }
      
        public int TicketId { get; set; }
        public int ReplyIdentifier { get; set; }
    }
    


}
