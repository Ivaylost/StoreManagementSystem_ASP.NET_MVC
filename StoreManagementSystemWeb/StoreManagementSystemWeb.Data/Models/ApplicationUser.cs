using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace StoreManagementSystemWeb.Data.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        
        public bool IsDeleted { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ShoppingCart ShoppingCart { get; }
    }
}
