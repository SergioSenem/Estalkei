﻿using AutoMapper;
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
        private readonly IExchangeRepository ExchangeRepository;
        private readonly IExchangeProductRepository ExchangeProductRepository;

        public ProductService(IProductRepository repository, IMapper mapper, IExchangeRepository exchangeRepository, IExchangeProductRepository exchangeProductRepository) : base(repository, mapper)
        {
            ExchangeRepository = exchangeRepository;
            ExchangeProductRepository = exchangeProductRepository;
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
    }
}
