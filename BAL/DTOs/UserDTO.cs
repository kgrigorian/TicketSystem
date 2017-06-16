using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace BAL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRole { get; set;}
        public int TicketsCreatedCount {get; set; }
        public int TicketsAssignedCount { get; set; }
    }
}
