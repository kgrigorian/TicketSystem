using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class ReplyService: BaseService
    {
        public ReplyService():base(ServiceConstatns.ServiceUrlPath["repliesUrlPath"])
        {

        }

        
       // public async Task<List<Models.Reply>> GetRepliesByTicketId(int ticket_id)
     //   {
      //      return await base.GetData<List<Models.Reply>(ticket_id.ToString());
     //   }


        public async Task<Models.Reply> GetReplyById(int id)
        {
            return await base.GetData<Models.Reply>(id.ToString());
        }

        public async Task<Reply> DeleteReply(int id)
        {
            return await base.DeleteData<Reply>(id.ToString());
        }

        public async Task<Reply> EditReply(Reply reply)
        {
            return await base.PutData<Reply>(reply);
        }

        public async Task<Reply> AddReply(Reply reply)
        {
            return await base.PostData<Reply>(reply);
        }
    }
}
