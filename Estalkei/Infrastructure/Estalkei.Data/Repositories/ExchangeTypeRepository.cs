using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Data.Repositories
{
    public class ExchangeTypeRepository : RepositoryBase<ExchangeType, EstalkeiContext>, IExchangeTypeRepository
    {
        public ExchangeTypeRepository(IContext context) : base(context)
        {
        }
    }
}
