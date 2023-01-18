using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using API.Models;

namespace API.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext() : base("name=APIContext")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
