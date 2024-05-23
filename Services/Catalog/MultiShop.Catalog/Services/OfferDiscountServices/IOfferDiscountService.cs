using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public interface IOfferDiscountService : IGenericService<ResultOfferDiscountDto, GetByIdOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto, OfferDiscount>
    {
    }
}
