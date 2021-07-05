using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CsvWebParser.Models
{
    // Entity Framework 6 Code-First Approach
    public class ProductsContext : DbContext
    {
        // EF Code-First API - Creates the DB for the specified connection string or we can manually run commands in the Package manager console to generate and execute the DB creation scripts
        public ProductsContext() : base("name=ProductConnection")
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}