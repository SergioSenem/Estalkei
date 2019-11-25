using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Contracts.Enums;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Estalkei.Services.Services
{
    public class ProductService : ServiceBase<ProductDto, Product, IProductRepository>, IProductService
    {

        public ProductService(IProductRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        public void UpdateQuantity(int productId, int exchangeQuantity, int type)
        {
            var product = Repository.GetById(productId);

            if (type == (int)ExchangeTypeEnum.Venda)
                exchangeQuantity *= -1;

            product.Quantity += exchangeQuantity;

            Repository.Update(product);
            Repository.SaveChanges();
        }

        public void UpdateQuantities(IEnumerable<ExchangeProductDto> exchangeProducts)
        {
            var products = Repository.GetByIds(exchangeProducts.Select(ep => ep.ProductId));

            foreach(var product in products)
            {
                var exchangeProduct = exchangeProducts.FirstOrDefault(ep => ep.ProductId == product.Id);

                if (exchangeProduct.Exchange == default)
                    continue;

                if (exchangeProduct.Exchange.ExchangeTypeId == (int)ExchangeTypeEnum.Venda)
                    product.Quantity -= exchangeProduct.Quantity;
                else
                    product.Quantity += exchangeProduct.Quantity;
            }

            Repository.UpdateRange(products);
            Repository.SaveChanges();
        }

        public IEnumerable<ProductDto> GetNotSoldInMonths(int months)
        {
            return Mapper.Map<IEnumerable<ProductDto>>(Repository.GetNotSoldInMonths(months));
        }
    }
}
