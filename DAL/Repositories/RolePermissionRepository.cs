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
    public class RolePermissionRepository : EFRepository<RolePermission>, IRolePermissionRepository
    {
        //see klass pärineb klassist EFRepository, mis tähendab, et ta võtab kõik meetodid, mis
        //EFRepositories olemas. Kuna EFRepositories ei ole ilma parametrita konstruktorit, mis tähendab, et kui
        //klassi liime mis pärib EFRepositoriest, siis selles klasiis ka konstruktori peab tegema.
        public RolePermissionRepository(IAppDbContext dbContext) : base(dbContext: dbContext)
        {
        }


        public List<RolePermission> GetOrderedRecords(int recordLimit, bool orderByRolePermission = true)
        {
            var query = RepositoryDbSet.AsQueryable();
            
            query = orderByRolePermission ? query.OrderBy(a => a.RolePermissionId) : query.OrderBy(a => a.UserRole);
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
