using Core.Domain.Interfaces;
using Estalkei.Domain.Entities;
using System.Collections.Generic;

namespace Estalkei.Domain.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetNotSoldInMonths(int months);
    }
}
