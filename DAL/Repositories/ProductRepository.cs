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
    public class ProductRepository : EFRepository<Product>, IProductRepository
    {
        //see klass pärineb klassist EFRepository, mis tähendab, et ta võtab kõik meetodid, mis
        //EFRepositories olemas. Kuna EFRepositories ei ole ilma parametrita konstruktorit, mis tähendab, et kui
        //klassi liime mis pärib EFRepositoriest, siis selles klasiis ka konstruktori peab tegema.
        public ProductRepository(IAppDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public List<Product> GetOrderedRecords(int recordLimit, bool orderByProductName = true)
        {
            var query = RepositoryDbSet.AsQueryable();
            
            query = orderByProductName ? query.OrderBy(a => a.ProductName) : query.OrderBy(a => a.ProductCategory);
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
