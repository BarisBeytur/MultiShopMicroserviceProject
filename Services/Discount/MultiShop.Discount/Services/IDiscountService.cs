using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task<ResultCouponDto> GetCouponByIdAsync(int id);
        Task CreateCouponAsync(CreateCouponDto couponDto);
        Task UpdateCouponAsync(UpdateCouponDto couponDto);
        Task DeleteCouponAsync(int id);
    }
}
