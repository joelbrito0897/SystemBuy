using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ventas.Models
{
    public class GlobalDbContext : DbContext
    {
        public GlobalDbContext() :base("SistemaVenta")
        {

        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Seller> Seller { get; set; }

        public DbSet<Factura> Factura { get; set; }
    }
}