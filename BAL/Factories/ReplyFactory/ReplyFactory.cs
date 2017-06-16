using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;
using Domain.Enums;

namespace BAL.Factories
{
    public class ReplyFactory : IReplyFactory

    {
    public ReplyDTO Create(Reply reply)
    {
        return new ReplyDTO()
        {
            ReplyId = reply.ReplyId,
            ReplyDtime = reply.ReplyDtime,
            ReplyText = reply.ReplyText,
            UserId = reply.UserId,      
            TicketId = reply.TicketId,
            ReplyIdentifier = reply.ReplyIdentifier
    };
    }
        public Reply Create(ReplyDTO dto)
        {
            return new Reply()
            {
                ReplyId = dto.ReplyId,
                ReplyDtime = dto.ReplyDtime,
                ReplyText = dto.ReplyText,
                UserId = dto.UserId,
                TicketId = dto.TicketId,
                ReplyIdentifier = dto.ReplyIdentifier
            };
        }

    }
}
