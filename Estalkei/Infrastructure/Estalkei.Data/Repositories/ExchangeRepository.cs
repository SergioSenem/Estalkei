using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Data.Repositories
{
    public class ExchangeRepository : RepositoryBase<Exchange, EstalkeiContext>, IExchangeRepository
    {
        public ExchangeRepository(IContext context) : base(context)
        {
        }
    }
}
