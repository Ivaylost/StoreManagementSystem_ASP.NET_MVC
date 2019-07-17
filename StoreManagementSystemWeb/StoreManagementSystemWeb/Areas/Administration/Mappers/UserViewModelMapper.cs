using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystemWeb.Areas.Administration.Mappers
{
    public class UserViewModelMapper: IViewModelMapper<ApplicationUser, UserViewModel>
    {


        public UserViewModel MapFrom(ApplicationUser entity)
            => new UserViewModel
            {
                Id = entity.Id,
                UserName=entity.UserName,
                Email = entity.Email,
                IsDeleted=entity.IsDeleted
            };

    
    }
}
