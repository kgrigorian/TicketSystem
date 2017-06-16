using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Interfaces;

namespace DAL.Repositories
{
    public class TicketHistoryRepository : EFRepository<TicketHistory>, ITicketHistoryRepository
    {
        //see klass pärineb klassist EFRepository, mis tähendab, et ta võtab kõik meetodid, mis
        //EFRepositories olemas. Kuna EFRepositories ei ole ilma parametrita konstruktorit, mis tähendab, et kui
        //klassi liime mis pärib EFRepositoriest, siis selles klasiis ka konstruktori peab tegema.
        public TicketHistoryRepository(IAppDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public List<TicketHistory> GetOrderedRecords(int recordLimit, bool orderByTicketStatusCode = true)
        {
            var query = RepositoryDbSet.AsQueryable();
            
            query = orderByTicketStatusCode ? query.OrderBy(a => a.TicketStatusCode) : query.OrderBy(a => a.TicketHisDtime);
            switch (recordLimit)
            {
                case 0:
                    break;
                default:
                    query= query.Take(count: recordLimit);
                    break;
            }
            return query.ToList();
        }
    }
}
