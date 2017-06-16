using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.Factories;
using Interfaces;

namespace BAL.Services
{
    public class ServiceGeneric<TDTO, TEntity> :IService<TDTO>
        where TDTO : class
        where TEntity: class
    {
        protected IFactory<TDTO, TEntity> EntityFactory;
        protected IRepository<TEntity> EntityRepository;

        public ServiceGeneric(IFactory<TDTO, TEntity> entityFactory, IRepository<TEntity> entityRepository)
        {
            this.EntityFactory = entityFactory;
            this.EntityRepository = entityRepository;
        }


        public List<TDTO> All()
        {
            return EntityRepository.All.Select(x => EntityFactory.Create(x)).ToList();
        }

        public TDTO GetById(int id)
        {
            var entity = EntityRepository.Find(id);
            if (null == entity)
            {
                return null;
            }
            return EntityFactory.Create(entity);
        }

        public TDTO Add(TDTO entity)
        {
            var domain = EntityFactory.Create(entity);

            var added = EntityRepository.Add(domain);
            EntityRepository.SaveChanges();
            return EntityFactory.Create(added);
        }

        public TDTO Delete(int id)
        {
            var deletedEntity = EntityRepository.Remove(id);
            if (null == deletedEntity)
            {
                return null;
            }
            EntityRepository.SaveChanges();
            return EntityFactory.Create(deletedEntity);
        }

        public TDTO Update(TDTO entity)
        {
            var domain = EntityFactory.Create(entity);
            EntityRepository.Update(domain);
            EntityRepository.SaveChanges();
            return EntityFactory.Create(domain);
        }
    }
}
