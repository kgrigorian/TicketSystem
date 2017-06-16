using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DAL;
using DAL.Repositories;
using ClientLib.Models;
using ClientLib.Services;

namespace ConsoleApp
{
    class Program
    {
        protected static UserService userService = new UserService();

        static void Main(string[] args)
        {
        #region db test

        //using (var ctx = new AppDbContext())
        //{
        //    var UserRepository = new UserRepository(dbContext: ctx);

        //    Console.WriteLine("--Writing users info: ");
        //    foreach (var user in UserRepository.GetOrderedRecords(1))
        //    {
        //        Console.WriteLine(value: user.UserId + " " + user.FirstLastName);
        //    }

        //    Console.WriteLine("--Writing products info: ");
        //    foreach (var product in ctx.Products)
        //    {
        //        Console.WriteLine(value: product.ProductId + " " + product.ProductName);
        //    }

        //    Console.WriteLine("--Writing tickets info: ");
        //    foreach (var ticket in ctx.Tickets)
        //    {
        //        Console.WriteLine(value: ticket.TicketId + " " + ticket.Description);
        //    }

        //    Console.WriteLine("--Writing replies info: ");
        //    foreach (var reply in ctx.Replies)
        //    {
        //        Console.WriteLine(value: reply.ReplyId + " " + reply.ReplyText);
        //    }

        //    Console.WriteLine("--Writing ticketHistory info: ");
        //    foreach (var ticketHistory in ctx.TicketHistory)
        //    {
        //        Console.WriteLine(value: ticketHistory.TicketHistoryId + " " + ticketHistory.TicketHisDtime);
        //    }


        //}
        //Console.WriteLine(value: "wtf");
        //Console.WriteLine(value: "Done!");

        #endregion

        MainAsync().Wait();
        }

    static async Task MainAsync()
        {
           //await DoSimpleGet();
           await DoSimplePut();
           //await DoSimpleDelete();
        }

        static async Task DoSimpleGet()
        {        
        var result =await  userService.GetAllUsers();
            foreach (var user in result)
           {
                Console.WriteLine(user.UserId);
                Console.WriteLine(user.FirstName);
                Console.WriteLine(user.LastName);
            }
        
           var result2 = await userService.GetUserById(1);
           Console.WriteLine("Result 2: " + result2.FirstName);

        }   

        static async Task DoSimplePost()
        {
            User user = new User
            {
                FirstName = "BOB",
                LastName = "OBO",
                UserEmail = "dfdf",
                //UserRole = 1

            };
            var result = await userService.AddUser(user);
        }

        static async Task DoSimplePut()
        {
            User user = new User
            {   
                UserId = 2,
                FirstName = "BOBaaaaaaaaaaa",
                LastName = "OBO",
                UserEmail = "asdasdasdasdadsasdaaaaaaaaaaa",
                UserRole = 1

            };
            var result = await userService.UpdateUser(user);
        }

        static async Task DoSimpleDelete()
        {            
            var result = await userService.DeleteUser(1);
        }
    }
}
