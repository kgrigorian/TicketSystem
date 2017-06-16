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
    public class UserRepository : EFRepository<User>, IUserRepository
    {
        //see klass pärineb klassist EFRepository, mis tähendab, et ta võtab kõik meetodid, mis
        //EFRepositories olemas. Kuna EFRepositories ei ole ilma parametrita konstruktorit, mis tähendab, et kui
        //klassi liime mis pärib EFRepositoriest, siis selles klasiis ka konstruktori peab tegema.
        public UserRepository(IAppDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public List<User> GetOrderedRecords(int recordLimit, bool orderByFirstName = true)
        {
            var query = RepositoryDbSet.AsQueryable();
            
            query = orderByFirstName ? query.OrderBy(a => a.FirstName) : query.OrderBy(a => a.LastName);
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
