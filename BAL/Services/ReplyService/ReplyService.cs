using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.ReplyService
{
    public class ReplyService : ServiceGeneric<ReplyDTO, Reply>, IReplyService
    {
        public ReplyService(IFactory<ReplyDTO, Reply> entityFactory, IRepository<Reply> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
