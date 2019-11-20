using AutoMapper;
using Core.Services.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;
using System;
using System.Linq;

namespace Estalkei.Services.Services
{
    public class ExchangeService : ServiceBase<ExchangeDto, Exchange, IExchangeRepository>, IExchangeService
    {
        private readonly IExchangeProductService ExchangeProductService;

        public ExchangeService(IExchangeRepository repository, IMapper mapper, IExchangeProductService exchangeProductService) : base(repository, mapper)
        {
            ExchangeProductService = exchangeProductService;
        }

        public override ExchangeDto Add(ExchangeDto newEntity)
        {
            if (newEntity.ExchangeProducts == default && newEntity.ExchangeProducts.Count() == 0)
                return default;

            newEntity.Date = DateTime.Now;
            var exchangeProducts = newEntity.ExchangeProducts.ToList();
            newEntity.ExchangeProducts = null;

            var entity = base.Add(newEntity);

            foreach(var exchangeProduct in exchangeProducts)
            {
                exchangeProduct.ExchangeId = entity.Id;
                exchangeProduct.Exchange = entity;
            }

            ExchangeProductService.AddRange(exchangeProducts);

            return entity;
        }

        public float GetMonthlyProfit(int month = 0)
        {
            if (month == 0)
                month = DateTime.Now.Month;

            return Repository.GetMonthProfit(month);
        }
    }
}
