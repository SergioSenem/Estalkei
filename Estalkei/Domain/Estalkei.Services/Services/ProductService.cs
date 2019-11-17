using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ProductService : ServiceBase<ProductDto, Product, IProductRepository>, IProductService
    {
        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
