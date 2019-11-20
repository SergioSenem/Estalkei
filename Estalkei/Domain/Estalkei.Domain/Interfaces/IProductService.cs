using Core.Domain.Interfaces;
using Estalkei.Contracts.Dtos;
using System.Collections.Generic;

namespace Estalkei.Domain.Interfaces
{
    public interface IProductService : IServiceBase<ProductDto>
    {
        void UpdateQuantity(int productId, int exchangeQuantity, int type);
        void UpdateQuantities(IEnumerable<ExchangeProductDto> exchangeProducts);
    }
}
