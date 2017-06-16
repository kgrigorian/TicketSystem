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
    public class TicketRepository : EFRepository<Ticket>, ITicketRepository
    {
        //see klass pärineb klassist EFRepository, mis tähendab, et ta võtab kõik meetodid, mis
        //EFRepositories olemas. Kuna EFRepositories ei ole ilma parametrita konstruktorit, mis tähendab, et kui
        //klassi liime mis pärib EFRepositoriest, siis selles klasiis ka konstruktori peab tegema.
        public TicketRepository(IAppDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public List<Ticket> GetOrderedRecords(int recordLimit, bool orderByDescription = true)
        {
            var query = RepositoryDbSet.AsQueryable();
            
            query = orderByDescription ? query.OrderBy(a => a.Description) : query.OrderBy(a => a.TicketId);
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
