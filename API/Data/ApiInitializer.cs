using System;
using System.Collections.Generic;
using API.Models;

namespace API.Data
{
    public class ApiInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApiContext>
    {
        protected override void Seed(ApiContext context)
        {
            var products = new List<Product>
            {
                new Product {CreatedAt = DateTime.Now, Name="Incredible Plastic Pants", Price=827, Brand="Hauck - Johnson", UpdatedAt=DateTime.Now },
                new Product {CreatedAt = DateTime.Now, Name="Electronic Wooden Tuna", Price=765, Brand="Johns - Farrell", UpdatedAt=DateTime.Now },
                new Product {CreatedAt = DateTime.Now, Name="Awesome Steel Mouse", Price=143, Brand="Paucek, Kuvalis and Zieme", UpdatedAt=DateTime.Now },

            };

            products.ForEach(p => { context.Products.Add(p); });
            context.SaveChanges();
        }

    }
}

