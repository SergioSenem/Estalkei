using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, EstalkeiContext>, IProductRepository
    {
        public ProductRepository(IContext context) : base(context)
        {
        }
    }
}
