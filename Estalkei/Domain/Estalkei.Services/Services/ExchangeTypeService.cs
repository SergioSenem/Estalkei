using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ExchangeTypeService : ServiceBase<ExchangeTypeDto, ExchangeType, IExchangeTypeRepository>, IExchangeTypeService
    {
        public ExchangeTypeService(IExchangeTypeRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
