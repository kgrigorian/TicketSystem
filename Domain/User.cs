using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class User
    {
        public int UserId { get; set;}
        [MaxLength(length: 128)]
        [MinLength(length: 1)]
        //[Required]
        public string FirstName { get; set; }

        [MaxLength(length: 128)]
        [MinLength(length: 1)]
        [Required]
        public string  LastName { get; set; }
        [MaxLength(length: 128)]
        [Required]
        public string UserEmail { get; set; }
        [MaxLength(length: 128)]
        [MinLength(length: 1)]
        [Required]
        public string Password { get; set; }

        //ENUM, In database integer type column appears
        public UserRole UserRole { get; set; }

        //Tickets created by User.
        [InverseProperty("User")]
        public virtual List<Ticket> TicketsCreated { get; set; } = new List<Ticket>();

        //Tickets assigned to Agent/Admin.
        [InverseProperty("Agent")]
        public virtual List<Ticket> TicketsAssigned { get; set; } = new List<Ticket>();

        //Ticket Replies
        public virtual List<Reply> Replies { get; set; } = new List<Reply>();

        //Ticket History
        public virtual List<TicketHistory> TicketHistory { get; set; }= new List<TicketHistory>();
        
        #region NotMapped
        //sama kui kirjutada näiteks "return FirstName + " " + LastName"
        public string FirstLastName => $"{FirstName} {LastName}".Trim();
        public string LastFirstName => $"{LastName} {FirstName}".Trim();
        #endregion

    }
}
