using Microsoft.EntityFrameworkCore;
using Sklep;

namespace DataAccesLayer
{
    public class SklepContext : DbContext
    {
        public DbSet<User> User {  get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<BasketPosition> BasketPosition { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderPosition> OrderPosition { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sklep;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

    }
}
    