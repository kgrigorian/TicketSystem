using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.DTOs
{
    public class RolePermissionDTO
    {
        public int RolePermissionId { get; set; }
        //enum
        public UserRole UserRole { get; set; }
        //enum
        public Permission Permission { get; set; }
    }
}
