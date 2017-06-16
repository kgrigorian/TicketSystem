using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Enums;

namespace DAL.Helpers
{
    class DbInitializator : DropCreateDatabaseIfModelChanges<AppDbContext>
    {
        protected override void Seed(AppDbContext context)
        {
            //Seed method ei tee mitte midagi
            //base.Seed(context);
            context.Users.Add(entity: new User
            {
                FirstName="Andres",
                LastName="Serdna",
                UserEmail = "andres@gmail.com",
                Password = "123456",
                UserRole = UserRole.Agent
            });

            context.Users.Add(entity: new User
            {
                FirstName = "Kalev",
                LastName = "Velak",
                UserEmail = "Kalev@gmail.com",
                Password="1234567",
                UserRole = UserRole.Admin
            });

            context.Products.Add(entity: new Product
            {
                ProductName = "Product 1",
                ProductCode = "1",
                ProductCategory = ProductCategory.Category1
            });

            context.Products.Add(entity: new Product
            {
                ProductName = "Product 2",
                ProductCode = "2",
                ProductCategory = ProductCategory.Category2
            });

            context.RolePermissions.Add(entity: new RolePermission
            {
                Permission = Permission.View_All_tickets,
                UserRole = UserRole.Agent
            });

            context.RolePermissions.Add(entity: new RolePermission
            {
                Permission = Permission.View_own_tickets,
                UserRole = UserRole.User
            });

            context.SaveChanges();

            context.Tickets.Add(entity: new Ticket
            {
                ReportedDtime = DateTime.Now,
                Description = "Ticket about Product 1",
                User = context.Users.First(),
                Agent = context.Users.Find(2),
                Product = context.Products.First(),
                TicketPriority = TicketPriority.Low
                
            });

            context.SaveChanges();

            context.Replies.Add(entity: new Reply
            {
                ReplyDtime = DateTime.Now,
                User = context.Users.First(),
                Ticket = context.Tickets.First(),
                ReplyText = "Some text",
                ReplyIdentifier = 1
            });

            context.TicketHistory.Add(entity: new TicketHistory
            {
                User = context.Users.First(),
                Ticket = context.Tickets.First(),
                TicketHisDtime = DateTime.Now,
                TicketStatusCode = TicketStatusCode.Received,                
            });



            context.SaveChanges();
        }
    }
}
