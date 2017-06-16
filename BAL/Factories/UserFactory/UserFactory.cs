using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAL.DTOs;
using Domain;
using Domain.Enums;

namespace BAL.Factories
{
    public class UserFactory:IUserFactory

    {
    public UserDTO Create(User user)
    {
        return new UserDTO()
        {
            UserId = user.UserId,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserEmail = user.UserEmail,
            UserPassword = user.Password,
            UserRole = (int)user.UserRole,
            TicketsAssignedCount = user.TicketsAssigned.Count,
            TicketsCreatedCount = user.TicketsCreated.Count
        };
    }
        public User Create(UserDTO dto)
        {
            return new User()
            {
                UserId = dto.UserId,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                UserEmail = dto.UserEmail,
                Password = dto.UserPassword,
                UserRole =(UserRole)dto.UserRole               
            };
        }

    }
}
