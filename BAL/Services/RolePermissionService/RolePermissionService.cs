using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.RolePermissionService
{
    public class RolePermissionService : ServiceGeneric<RolePermissionDTO, RolePermission>, IRolePermissionService
    {
        public RolePermissionService(IFactory<RolePermissionDTO, RolePermission> entityFactory, IRepository<RolePermission> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
