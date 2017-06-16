using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace DAL.Repositories
{
    public class EFRepository<TEntity>: IRepository<TEntity>
        where TEntity : class //selline konstruktsioon piirab generiku võimalikud tüübid. nüüd peab olema klass ja ei midagu muud
    {
        //andmebaasi ühendus peab olema ainult 1, ei tohi igasse metodisse kirjutada eraldi
        //tuleb seda kuskilt väljaspoolt saada

        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;

        public EFRepository(IAppDbContext dbContext)
        {
            RepositoryDbContext = dbContext as DbContext;
            if (RepositoryDbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
            RepositoryDbSet = RepositoryDbContext.Set<TEntity>();

            if (RepositoryDbSet == null)
            {
                throw new NullReferenceException(nameof(RepositoryDbSet));
            }

        }

        public List<TEntity> All
        {
            get
            {
                var resCount = RepositoryDbSet.Count();
                if (resCount < 10)
                {
                    return RepositoryDbSet.ToList();
                }
                throw new Exception(message: "Too many records in resultset! Please add customer data access method to repository");
            }
        }

        public TEntity Find(int id)
        {
            return RepositoryDbSet.Find(id);
        }

        public TEntity Remove(int id)
        {

            return Remove(entity: Find(id: id));
        }

        public TEntity Remove(TEntity entity)
        {
            return RepositoryDbSet.Remove(entity: entity);
        }

        public TEntity Add(TEntity entity)
        {
            return RepositoryDbSet.Add(entity: entity);
        }
            
        public TEntity Update(TEntity entity)
        {
            RepositoryDbContext.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public int SaveChanges()
        {
            return RepositoryDbContext.SaveChanges();
        }
    }
}
