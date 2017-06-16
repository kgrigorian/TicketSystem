using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public string ProductCode { get; set; }

        //enum
        public ProductCategory ProductCategory { get; set; }

        //Product tickets
        public virtual List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
