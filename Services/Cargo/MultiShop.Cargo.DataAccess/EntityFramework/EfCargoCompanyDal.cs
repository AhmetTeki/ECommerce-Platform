using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.DataAccess.Concrete;
using MultiShop.Cargo.DataAccess.Repositories;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.DataAccess.EntityFramework;

public class EfCargoCompanyDal:GenericRepository<CargoCompany>, ICargoCompanyDal
{
    public EfCargoCompanyDal(CargoContext context) : base(context)
    {
    }
}