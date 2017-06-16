using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Helpers;
using Interfaces;

namespace DAL
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet <Ticket> Tickets { get; set; }
        public DbSet<TicketHistory> TicketHistory { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Product> Products { get; set; }

        public AppDbContext() : base(nameOrConnectionString: "name=AppDbConnectionString")
        {
            Database.SetInitializer(strategy: new DbInitializator());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<AppDbContext>());

#if DEBUG   //Kui Debug reziimis, siis prinditakse Outputis, kui Release reziimis siis Console-s
            Database.Log = s => Trace.Write(value: s.Contains(value: "SELECT") ? s : "");
#else
            Database.Log = s => Console.WriteLine(value: s.Contains(value:"SELECT") ? s : "");
#endif

        }
    }
}
