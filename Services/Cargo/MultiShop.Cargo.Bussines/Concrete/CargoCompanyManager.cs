using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Bussines.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal;

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    public async Task TInsertAsync(CargoCompany entity)
    {
        await _cargoCompanyDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoCompany entity)
    {
        await _cargoCompanyDal.UpdateAsync(entity);
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoCompanyDal.DeleteAsync(id);
    }

    public async Task<CargoCompany> TGetByIdAsync(int id)
    {
        CargoCompany values = await _cargoCompanyDal.GetByIdAsync(id);
        return values;
    }

    public async Task<List<CargoCompany>> TGetAllAsync()
    {
        List<CargoCompany> values = await _cargoCompanyDal.GetAllAsync();
        return values;
    }
}