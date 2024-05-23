using AutoMapper;
using MultiShop.Catalog.Dtos.Category;
using MultiShop.Catalog.Dtos.Feature;
using MultiShop.Catalog.Dtos.FeatureSlider;
using MultiShop.Catalog.Dtos.OfferDiscount;
using MultiShop.Catalog.Dtos.Product;
using MultiShop.Catalog.Dtos.ProductDetail;
using MultiShop.Catalog.Dtos.ProductImage;
using MultiShop.Catalog.Dtos.SpecialOffer;
using MultiShop.Catalog.Entities;

namespace MultiShop.Catalog.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category,ResultCategoryDto>().ReverseMap();
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category,GetByIdCategoryDto>().ReverseMap();
                
            CreateMap<Product,ResultProductDto>().ReverseMap();
            CreateMap<Product,CreateProductDto>().ReverseMap();
            CreateMap<Product,UpdateProductDto>().ReverseMap();
            CreateMap<Product,GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail,ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail,GetByIdProductDetailDto>().ReverseMap();

            CreateMap<SpecialOffer, ResultSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, CreateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, UpdateSpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, GetByIdSpecialOfferDto>().ReverseMap();

            CreateMap<FeatureSlider, ResultFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, CreateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, UpdateFeatureSliderDto>().ReverseMap();
            CreateMap<FeatureSlider, GetByIdFeatureSliderDto>().ReverseMap();

            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();

            CreateMap<OfferDiscount, ResultOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, CreateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, UpdateOfferDiscountDto>().ReverseMap();
            CreateMap<OfferDiscount, GetByIdOfferDiscountDto>().ReverseMap();


            CreateMap<ProductImage,ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage,CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage,GetByIdProductImageDto>().ReverseMap();

            CreateMap<Product,ResultProductsWithCategoryDto>().ReverseMap();
        }
    }
}
