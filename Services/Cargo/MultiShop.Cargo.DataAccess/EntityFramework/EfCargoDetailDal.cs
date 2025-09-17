using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccess.Repositories;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.EntityFramework;

public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
    public EfCargoDetailDal(CargoContext context) : base(context)
    {
    }
}