using coffeehouse_api.Models;
using coffeehouse_api.Models.User;
using Microsoft.EntityFrameworkCore;
using Type = coffeehouse_api.Models.Type;

namespace Museum.Data
{
    public class CoffeeHouseContext : DbContext
    {
        public CoffeeHouseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Type> Types { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CompoundGrammProduct> CompoundGrammProducts { get; set; }
        public DbSet<Compound> Compounds { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ProductInCart> ProductInCarts { get; set; }
        public DbSet<DeliveryData> DeliveryDatas { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Role> Roles { get; set; }
       
    }
}
