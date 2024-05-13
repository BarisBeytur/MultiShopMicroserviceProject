using AutoMapper;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public class SpecialOfferService : GenericService<ResultSpecialOfferDto, GetByIdSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, SpecialOffer>, ISpecialOfferService
    {
        public SpecialOfferService(IDatabaseSettings _databaseSettings, IMapper mapper) : base(_databaseSettings, mapper)
        {
        }

    }
}
