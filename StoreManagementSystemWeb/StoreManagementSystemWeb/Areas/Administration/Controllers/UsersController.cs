using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreManagementSystemWeb.Areas.Administration.Mappers;
using StoreManagementSystemWeb.Areas.Administration.Models;
using StoreManagementSystemWeb.Data;
using StoreManagementSystemWeb.Data.Models;
using StoreManagementSystemWeb.Models;
using StoreManagementSystemWeb.Services.Interfaces;

namespace StoreManagementSystemWeb.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly IUserService userservice;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IViewModelMapper<IReadOnlyCollection<ApplicationUser>, AdminViewModel> homeViewModelMapper;

        public UsersController(IUserService userservice, 
            IViewModelMapper<IReadOnlyCollection<ApplicationUser>, AdminViewModel> homeViewModelMapper,
            ApplicationDbContext context,
            UserManager<ApplicationUser> usermanager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userservice = userservice ?? throw new ArgumentNullException(nameof(userservice));
            this.homeViewModelMapper = homeViewModelMapper ?? throw new ArgumentNullException(nameof(homeViewModelMapper));
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.usermanager = usermanager ?? throw new ArgumentNullException(nameof(usermanager));
            this.roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            var users = this.userservice.GetAllUsers();

            var model = this.homeViewModelMapper.MapFrom(users);

            return View("Users", model);
        }



        [Route("Administration/Users/MakeAdmin/{id}")]
        public async Task<IActionResult> MakeAdmin(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Users");
            }

            var user = this.userservice.GetUserById(model.Id);
            var roles = await this.usermanager.GetRolesAsync(user);
            if (!roles.Any(x => x == "Admin"))
            {
                await this.usermanager.AddToRoleAsync(user, "Admin");
            }
            this.context.Attach(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Users");
        }

        private bool UserExists(string id)
        {
            return context.Users.Any(e => e.Id == id);
        }

        [Route("Administration/Users/RevokeAdmin/{id}")]
        public async Task<IActionResult> RevokeAdmin(UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Users");
            }

            var user = await this.usermanager.FindByIdAsync(model.Id);
            var roles = await this.usermanager.GetRolesAsync(user);
            if (roles.Any(x => x == "Admin"))
            {
                await this.usermanager.RemoveFromRoleAsync(user, "Admin");
            }

            this.context.Attach(user).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction("Users");
        }

    }
}