using Dapper;
using Microsoft.Data.SqlClient;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {

        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto couponDto)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();

            parameters.Add("@code", couponDto.Code);
            parameters.Add("@rate", couponDto.Rate);
            parameters.Add("@isActive", couponDto.IsActive);
            parameters.Add("@validDate", couponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }

        public async Task DeleteCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE Id = @id";

            var parameters = new DynamicParameters();
            parameters.Add("@id", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";

            using (var connection = _dapperContext.CreateConnection())
            {
                return (await connection.QueryAsync<ResultCouponDto>(query)).ToList();
            }
        }

        public async Task<ResultCouponDto> GetCouponByIdAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE Id = @id";

            var parameters = new DynamicParameters();

            parameters.Add("@id", id);

            using (var connection = _dapperContext.CreateConnection())
            {
                return await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto couponDto)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE Id = @id";

            var parameters = new DynamicParameters();

            parameters.Add("@id", couponDto.Id);
            parameters.Add("@code", couponDto.Code);
            parameters.Add("@rate", couponDto.Rate);
            parameters.Add("@isActive", couponDto.IsActive);
            parameters.Add("@validDate", couponDto.ValidDate);

            using (var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
