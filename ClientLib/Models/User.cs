using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClientLib.Models
{
    public class User
    {

        //JsonProperty("UserId")] - if model property name differ from json, this annotation can be used to map data.
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        [Range(0, 2, ErrorMessage = "Select a correct UserRole")]
        public int UserRole { get; set; }
    }
    

//    "$id": "1",
//    "userId": 1,
//    "firstName": "Andres",
//    "lastName": "Serdna",
//    "userEmail": "andres@gmail.com",
//    "userRole": 0,
//    "ticketsCreatedCount": 1,
//    "ticketsAssignedCount": 0
//}

}
