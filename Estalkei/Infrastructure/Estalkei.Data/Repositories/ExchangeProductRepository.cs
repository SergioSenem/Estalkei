using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Data.Repositories
{
    public class ExchangeProductRepository : RepositoryBase<ExchangeProduct, EstalkeiContext>, IExchangeProductRepository
    {
        public ExchangeProductRepository(IContext context) : base(context)
        {
        }
    }
}
