using AutoMapper;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;

namespace Estalkei.Domain.Profiles
{
    public class EstalkeiProfile : Profile
    {
        public EstalkeiProfile()
        {
            CreateMap<Provider, ProviderDto>().ReverseMap();
            CreateMap<ExchangeType, ExchangeTypeDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Exchange, ExchangeDto>().ReverseMap();
            CreateMap<ExchangeProduct, ExchangeProductDto>().ReverseMap();
        }
    }
}
