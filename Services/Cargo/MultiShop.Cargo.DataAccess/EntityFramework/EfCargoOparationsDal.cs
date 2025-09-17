using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccess.Repositories;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.EntityFramework;

public class EfCargoOparationsDal : GenericRepository<CargoOparations>,  ICargoOparationsDal
{
    public EfCargoOparationsDal(CargoContext context) : base(context)
    {
    }
}