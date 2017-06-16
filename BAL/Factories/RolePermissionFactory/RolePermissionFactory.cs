using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;
using Domain.Enums;

namespace BAL.Factories
{
    public class RolePermissionFactory : IRolePermissionFactory

    {
    public RolePermissionDTO Create(RolePermission rolePermission)
    {
        return new RolePermissionDTO()
        {
            RolePermissionId = rolePermission.RolePermissionId,
            UserRole = rolePermission.UserRole,
            Permission = rolePermission.Permission,
    };
    }
        public RolePermission Create(RolePermissionDTO dto)
        {
            return new RolePermission()
            {
                RolePermissionId = dto.RolePermissionId,
                UserRole = dto.UserRole,
                Permission = dto.Permission,
            };
        }

    }
}
