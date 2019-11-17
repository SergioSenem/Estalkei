using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ExchangeService : ServiceBase<ExchangeDto, Exchange, IExchangeRepository>, IExchangeService
    {
        public ExchangeService(IExchangeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
