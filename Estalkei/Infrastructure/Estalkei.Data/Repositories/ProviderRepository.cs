using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Data.Repositories
{
    public class ProviderRepository : RepositoryBase<Provider, EstalkeiContext>, IProviderRepository
    {
        public ProviderRepository(IContext context) : base(context)
        {
        }
    }
}
