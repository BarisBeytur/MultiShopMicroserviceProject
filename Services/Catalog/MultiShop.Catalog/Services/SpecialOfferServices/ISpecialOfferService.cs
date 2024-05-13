using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.GenericService;

namespace MultiShop.Catalog.Services.SpecialOfferServices
{
    public interface ISpecialOfferService : IGenericService<ResultSpecialOfferDto, GetByIdSpecialOfferDto, CreateSpecialOfferDto, UpdateSpecialOfferDto, SpecialOffer>
    {
    }
}
