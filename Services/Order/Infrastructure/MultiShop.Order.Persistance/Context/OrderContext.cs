using Microsoft.EntityFrameworkCore;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Persistance.Context;

public class OrderContext : DbContext
{
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1434;Database=MultiShopOrderDb;User=sa;Password=Ahmet0234.;");
    }

    public DbSet<Address> Addresses { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<Ordering> Orderings { get; set; }
}