using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Bussines.Concrete;

public class CargoOparationManager : ICargoOparationService
{
    private readonly ICargoOparationsDal _cargoOparationsDal;

    public CargoOparationManager(ICargoOparationsDal cargoOparationsDal)
    {
        _cargoOparationsDal = cargoOparationsDal;
    }

    public async Task TInsertAsync(CargoOparations entity)
    {
        await _cargoOparationsDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoOparations entity)
    {
        await _cargoOparationsDal.UpdateAsync(entity);
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoOparationsDal.DeleteAsync(id);
    }

    public async Task<CargoOparations> TGetByIdAsync(int id)
    {
        CargoOparations values = await _cargoOparationsDal.GetByIdAsync(id);
        return values;
    }

    public async Task<List<CargoOparations>> TGetAllAsync()
    {
        List<CargoOparations> values = await _cargoOparationsDal.GetAllAsync();
        return values;
    }
}