using Inventory.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DAL.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> Options) : base(Options)
        {
                
        }
        public DbSet<Product> products { get; set; }

        public DbSet<ProductDetails> productDetails { get; set; }

        public DbSet<Order> orders { get; set; }
        public DbSet<Supplier> suppliers { get; set; }

        public DbSet<UserInfo>users { get; set; }
        

    }
}
