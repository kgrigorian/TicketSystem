using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository<TEntity>
    {
        //IQueryable <TEntity> All {get;} - annab pooliku SQLi lause, kasuta parem List

        List<TEntity> All {get;}

        TEntity Find(int id);
        TEntity Remove(int id);
        TEntity Remove(TEntity entity);

        TEntity Add(TEntity entity);

        TEntity Update(TEntity entity);

        int SaveChanges();


    }
}
