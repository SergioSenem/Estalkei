using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ExchangeProductService : ServiceBase<ExchangeProductDto, ExchangeProduct, IExchangeProductRepository>, IExchangeProductService
    {
        public ExchangeProductService(IExchangeProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
