using Microsoft.EntityFrameworkCore;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreManagementSystemWeb.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public IReadOnlyCollection<ApplicationUser> GetAllUsers()
        {
            return this.context.Users
                .ToList();
        }


        public ApplicationUser GetUserById(string userId)
        {
           return this.context.Users.FirstOrDefault(u => u.Id == userId);
        }



    }
}
