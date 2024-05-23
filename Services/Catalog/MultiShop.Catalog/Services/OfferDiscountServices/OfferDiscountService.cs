using AutoMapper;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.OfferDiscountServices
{
    public class OfferDiscountService : GenericService<ResultOfferDiscountDto, GetByIdOfferDiscountDto, CreateOfferDiscountDto, UpdateOfferDiscountDto, OfferDiscount> , IOfferDiscountService
    {
        public OfferDiscountService(IDatabaseSettings databaseSettings, IMapper mapper) : base(databaseSettings, mapper)
        {

        }
    }
}
