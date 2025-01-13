using Microsoft.EntityFrameworkCore;
using Model;

namespace DataBaseAppBack
{
    public class ModelContext : DbContext
    {
        public ModelContext(DbContextOptions options) : base(options) {}    

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Selling> Sellings { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
