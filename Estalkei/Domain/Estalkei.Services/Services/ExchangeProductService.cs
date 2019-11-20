using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Services.Services
{
    public class ExchangeProductService : ServiceBase<ExchangeProductDto, ExchangeProduct, IExchangeProductRepository>, IExchangeProductService
    {
        private readonly IProductService ProductService;

        public ExchangeProductService(IExchangeProductRepository repository, IMapper mapper, IProductService productService) : base(repository, mapper)
        {
            ProductService = productService;
        }

        public override ExchangeProductDto Add(ExchangeProductDto newEntity)
        {
            var entity = base.Add(newEntity);

            ProductService.UpdateQuantity(newEntity.ProductId, newEntity.Quantity, newEntity.Exchange.ExchangeTypeId);

            return entity;
        }

        public override void AddRange(IEnumerable<ExchangeProductDto> newEntities)
        {
            var entitiesToAdd = newEntities.Select(e => new ExchangeProductDto() { Id = e.Id, ExchangeId = e.ExchangeId, ProductId = e.ProductId, Quantity = e.Quantity });

            base.AddRange(entitiesToAdd);
            ProductService.UpdateQuantities(newEntities);
        }
    }
}
