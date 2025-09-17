using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Bussines.Concrete;

public class CargoCutomerManager  : ICargoCustomerService
{
    private readonly ICargoCustomerDal  _cargoCustomerDal;

    public CargoCutomerManager(ICargoCustomerDal cargoCustomerDal)
    {
        _cargoCustomerDal = cargoCustomerDal;
    }

    public async Task TInsertAsync(CargoCustomer entity)
    {
       await _cargoCustomerDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoCustomer entity)
    {
        await _cargoCustomerDal.UpdateAsync(entity);
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoCustomerDal.DeleteAsync(id);
    }

    public async Task<CargoCustomer> TGetByIdAsync(int id)
    {
       CargoCustomer values = await _cargoCustomerDal.GetByIdAsync(id);
       return values;
    }

    public async Task<List<CargoCustomer>> TGetAllAsync()
    {
        List<CargoCustomer> values = await _cargoCustomerDal.GetAllAsync();
        return values;
    }
}