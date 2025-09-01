using System.Data;
using Dapper;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _dapperContext;

    public DiscountService(DapperContext dapperContext)
    {
        _dapperContext = dapperContext;
    }

    public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
    {
        string sql = "SELECT * FROM Coupons";
        
        using (IDbConnection connection= _dapperContext.CreateConnection)
        {
            IEnumerable<ResultCouponDto> result = await connection.QueryAsync<ResultCouponDto>(sql);
            return result.ToList();
        }
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
       string sql = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@Code, @Rate, @IsActive, @ValidDate)";
       DynamicParameters paramaters = new DynamicParameters();
       paramaters.Add("@Code", createCouponDto.Code);
       paramaters.Add("@Rate", createCouponDto.Rate);
       paramaters.Add("@IsActive", createCouponDto.IsActive);
       paramaters.Add("@ValidDate", createCouponDto.ValidDate);
       using (IDbConnection connection= _dapperContext.CreateConnection)
       {
           await connection.ExecuteAsync(sql, paramaters);
       }
    }

    public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        string sql = "UPDATE Coupons SET Code=@Code, Rate=@Rate, IsActive=@IsActive, ValidDate=@ValidDate WHERE CouponId=@CouponId";
        DynamicParameters paramaters = new DynamicParameters();
        paramaters.Add("@Code", updateCouponDto.Code);
        paramaters.Add("@Rate", updateCouponDto.Rate);
        paramaters.Add("@IsActive", updateCouponDto.IsActive);
        paramaters.Add("@ValidDate", updateCouponDto.ValidDate);
        paramaters.Add("@CouponId", updateCouponDto.CouponId);
        using (IDbConnection connection= _dapperContext.CreateConnection)
        {
            await connection.ExecuteAsync(sql, paramaters);
        }
    }

    public async Task DeleteCouponAsync(int id)
    {
       string sql = "DELETE FROM Coupons WHERE CouponId=@CouponId";
       DynamicParameters paramaters = new DynamicParameters();
       paramaters.Add("@CouponId", id);
       using (IDbConnection connection= _dapperContext.CreateConnection)
       {
           await connection.ExecuteAsync(sql, paramaters);
       }
    }

    public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
    {
        string sql = "SELECT * FROM Coupons WHERE CouponId = @CouponId";
        DynamicParameters paramaters = new DynamicParameters();
        paramaters.Add("@CouponId", id);
        using (IDbConnection connection = _dapperContext.CreateConnection)
        {
           GetByIdCouponDto? values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(sql, paramaters);
           return values;
        }
    }
}