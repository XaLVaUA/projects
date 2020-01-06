using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualBasic;
using Task5_2.DAL.Entities;

namespace Task5_2.DAL
{
    public class StoreInitializer : DropCreateDatabaseIfModelChanges<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            var categories = new List<Category>
            {
                new Category()
                {
                    Name = "Electronics"
                },
                new Category()
                {
                    Name = "Sport"
                },
                new Category()
                {
                    Name = "Tools"
                }
            };

            var suppliers = new List<Supplier>()
            {
                new Supplier()
                {
                    Name = "Andrij",
                    City = "Kyiv"
                },
                new Supplier()
                {
                    Name = "Bogdan",
                    City = "Kyiv"
                },
                new Supplier()
                {
                    Name = "Ivan",
                    City = "Lviv"
                }
            };

            var products = new List<Product>()
            {
                new Product()
                {
                    Name = "Iphone",
                    Price = 30000,
                    Category = categories[0],
                    Supplier = suppliers[0]
                },
                new Product()
                {
                    Name = "TV",
                    Price = 40000,
                    Category = categories[0],
                    Supplier = suppliers[1]
                },
                new Product()
                {
                    Name = "Bike",
                    Price = 8000,
                    Category = categories[1],
                    Supplier = suppliers[1]
                },
                new Product()
                {
                    Name = "Skate",
                    Price = 3000,
                    Category = categories[1],
                    Supplier = suppliers[1]
                },
                new Product()
                {
                    Name = "Wrench",
                    Price = 300,
                    Category = categories[2],
                    Supplier = suppliers[2]
                },
                new Product()
                {
                    Name = "Galaxy",
                    Price = 25000,
                    Category = categories[0],
                    Supplier = suppliers[0]
                }
            };

            context.Products.AddRange(products);
        }
    }
}