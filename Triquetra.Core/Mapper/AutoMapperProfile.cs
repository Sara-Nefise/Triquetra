using AutoMapper;
using Triquetra.Domain.Data.Entities;
using Triquetra.Domain.DTO.ExchangeRates;
using Triquetra.Domain.DTO.Offers;
using Triquetra.Domain.DTO.Products;
using Triquetra.Domain.DTO.ProductTypes;

namespace Triquetra.Core.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductType, ProductTypeDTO>();
            CreateMap<Offer, OfferDTO>();
            CreateMap<ExchangeRate, ExchangeRateDTO>();
        }
    }
}