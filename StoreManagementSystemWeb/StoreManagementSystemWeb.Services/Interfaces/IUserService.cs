using StoreManagementSystemWeb.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Services.Interfaces
{
    public interface IUserService
    {
        IReadOnlyCollection<ApplicationUser> GetAllUsers();

        ApplicationUser GetUserById(string userId);
    }
}
