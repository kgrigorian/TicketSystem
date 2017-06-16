using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public DateTime ReplyDtime { get; set; }
        public string ReplyText { get; set; }
        //User FK
        public int? UserId { get; set; }
        public virtual User User { get; set; }
        //Ticket FK
        public int TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
        public int ReplyIdentifier { get; set; }
    }
}
