using Microsoft.EntityFrameworkCore;
using StoreManagementSystemWeb.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreManagementSystemWeb.Test.Utils
{
    public static class TestUtils
    {
        public static DbContextOptions<ApplicationDbContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName).Options;
        }

    }
}
