using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.Concrete;

public class CargoContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1436;Database=MultiShopCargoDb;User=sa;Password=Ahmet0234.;");
    }
    
    public DbSet<CargoCompany>  CargoCompanies { get; set; }
    public DbSet<CargoDetail>  CargoDetails { get; set; }
    public DbSet<CargoCustomer>  CargoCustomers { get; set; }
    public DbSet<CargoOparations>  CargoOparations { get; set; }
}