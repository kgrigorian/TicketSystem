using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ClientLib.Models;

namespace ClientLib.Services
{
    public class UserService: BaseService
    {
        public UserService():base(ServiceConstatns.ServiceUrlPath["usersUrlPath"])
        {

        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            
            return await base.GetData<List<Models.User>>("");
        }

        public async Task<Models.User> GetUserById(int id)
        {
            return await base.GetData<Models.User>(id.ToString());
        }

        public async Task<User> DeleteUser(int id)
        {
            return await base.DeleteData<User>(id.ToString());
        }

        public async Task<User> UpdateUser(User user)
        {
            return await base.PutData<User>(user);
        }

        public async Task<User> AddUser(User user)
        {
            return await base.PostData<User>(user);
        }
    }
}
