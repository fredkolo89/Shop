using System.Data.Entity;
using Shop.Models;

namespace Shop.DAL
{
    public class ShopContext : DbContext
    {
        public ShopContext()
            : base("ConnectionShop")
        {

        }

        static ShopContext()
        {
            Database.SetInitializer<ShopContext>(new ShopInitialaizer());
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<PositionOrder> PositionOrder { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}