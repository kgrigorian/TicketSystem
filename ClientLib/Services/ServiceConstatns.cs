using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Services
{
    public class ServiceConstatns
    {
        public static Dictionary<string, string> ServiceUrlPath = new Dictionary<string, string>
        {
            {"usersUrlPath","http://localhost:14243/api/users/" },
            {"ticketsUrlPath","http://localhost:14243/api/tickets/" },
            {"ticketHistoryUrlPath","http://localhost:14243/api/tickethistory/" },
            {"rolePermissionUrlPath","http://localhost:14243/api/rolepermissions/" },
            {"repliesUrlPath","http://localhost:14243/api/replies/" },
            {"productsUrlPath","http://localhost:14243/api/products/" }
        };

    }
}
