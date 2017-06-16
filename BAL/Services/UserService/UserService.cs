using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using BAL.Factories;
using Domain;
using Interfaces;

namespace BAL.Services.UserService
{
    public class UserService:ServiceGeneric<UserDTO, User>, IUserService
    {
        public UserService(IFactory<UserDTO, User> entityFactory, IRepository<User> entityRepository) : base(entityFactory, entityRepository)
        {
        }
    }
}
