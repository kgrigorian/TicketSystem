using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class RolePermission
    {
        public int RolePermissionId { get; set; }
        //enum
        public UserRole UserRole { get; set; }
        //enum
        public Permission Permission { get; set; }
    }
}
