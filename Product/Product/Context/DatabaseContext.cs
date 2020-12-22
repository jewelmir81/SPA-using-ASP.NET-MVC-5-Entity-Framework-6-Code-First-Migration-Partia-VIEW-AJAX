using Product.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Product.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(): base("ProductDB")
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}