using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ProductService : ServiceBase<ProductDto, Product, IProductRepository>, IProductService
    {
        private readonly IExchangeRepository ExchangeRepository;
        private readonly IExchangeProductRepository ExchangeProductRepository;

        public ProductService(IProductRepository repository, IMapper mapper, IExchangeRepository exchangeRepository, IExchangeProductRepository exchangeProductRepository) : base(repository, mapper)
        {
            ExchangeRepository = exchangeRepository;
            ExchangeProductRepository = exchangeProductRepository;
        }
    }
}
