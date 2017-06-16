using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class RolePermissionsService: BaseService
    {
        public RolePermissionsService():base(ServiceConstatns.ServiceUrlPath["rolePermissionUrlPath"])
        {

        }

        public async Task<List<Models.RolePermission>> GetAllRolePermissions()
        {
            return await base.GetData<List<Models.RolePermission>>("");

        }

        public async Task<Models.RolePermission> GetRolePermissionById(int id)
        {
            return await base.GetData<Models.RolePermission>(id.ToString());
        }

        public async Task<RolePermission> DeleteRolePermission(int id)
        {
            return await base.DeleteData<RolePermission>(id.ToString());
        }

        public async Task<RolePermission> UpdateUser(RolePermission rp)
        {
            return await base.PutData<RolePermission>(rp);
        }

        public async Task<RolePermission> AddRolePermission(RolePermission rp)
        {
            return await base.PostData<RolePermission>(rp);
        }
    }
}
