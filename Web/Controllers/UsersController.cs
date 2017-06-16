using ClientLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ClientLib.Services;


namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private static ClientLib.Services.UserService _userService = new UserService();

        // GET: Users
        public async Task<ActionResult> Index()
        {
            List<User> users =  await _userService.GetAllUsers();

            return View(users);
        }

        // GET: Users/Details/5
        public async Task<ActionResult> Details(int id)
        {
            User user = await _userService.GetUserById(id);
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                User user = convertToUser(collection);

                await _userService.AddUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            User user = await _userService.GetUserById(id);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                User user= convertToUser(collection);
                await _userService.UpdateUser(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: Users/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {               
                await _userService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private User convertToUser(FormCollection collection)
        {
            return new User
            {
                UserId = Convert.ToInt32(collection["UserId"]),
                FirstName = collection["FirstName"],
                LastName =collection["LastName"],
                UserEmail = collection["UserEmail"],
                UserPassword = collection["UserPassword"],
                UserRole = Convert.ToInt32(collection["UserRole"])
            };
            
        }

    }
}
