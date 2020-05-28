using System.Data.Entity;

namespace DAL
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("name=ShopConnect")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}