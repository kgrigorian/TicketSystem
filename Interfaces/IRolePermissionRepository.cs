using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Interfaces
{
    public interface IRolePermissionRepository : IRepository<RolePermission>
    {
        //siin tuleb custom meetodid kirja panna, esimesena siis kirjuta vastavas interfaces ja teisena siis vastavas repositories implementatsioon.
           
        List<RolePermission> GetOrderedRecords(int recordLimit, bool orderByRolePermission = true);
    }
}
