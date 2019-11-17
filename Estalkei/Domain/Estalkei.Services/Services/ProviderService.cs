using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ProviderService : ServiceBase<ProviderDto, Provider, IProviderRepository>, IProviderService
    {
        public ProviderService(IProviderRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
