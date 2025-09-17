using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DataAccess.Abstract;
using MultiShop.Cargo.Entity.Concrete;

namespace MultiShop.Cargo.Bussines.Concrete;

public class CargoDetailManager : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public async Task TInsertAsync(CargoDetail entity)
    {
        await _cargoDetailDal.InsertAsync(entity);
    }

    public async Task TUpdateAsync(CargoDetail entity)
    {
        await _cargoDetailDal.UpdateAsync(entity);
    }

    public async Task TDeleteAsync(int id)
    {
        await _cargoDetailDal.DeleteAsync(id);
    }

    public async Task<CargoDetail> TGetByIdAsync(int id)
    {
        CargoDetail values = await _cargoDetailDal.GetByIdAsync(id);
        return values;
    }

    public async Task<List<CargoDetail>> TGetAllAsync()
    {
        List<CargoDetail> values = await _cargoDetailDal.GetAllAsync();
        return values;
    }
}