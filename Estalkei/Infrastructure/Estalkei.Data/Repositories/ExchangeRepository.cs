using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Contracts.Enums;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Estalkei.Data.Repositories
{
    public class ExchangeRepository : RepositoryBase<Exchange, EstalkeiContext>, IExchangeRepository
    {
        public ExchangeRepository(IContext context) : base(context)
        {
        }

        public float GetMonthProfit(int month)
        {
            var sells = (from e in DbSet
                         join ep in Context.Set<ExchangeProduct>()
                         on e.Id equals ep.ExchangeId
                         join p in Context.Set<Product>()
                         on ep.ProductId equals p.Id
                         where e.Date.Month == month
                         && e.ExchangeTypeId == (int)ExchangeTypeEnum.Venda
                         select ep.Quantity * p.SellPrice).Sum();

            var expanses = (from e in DbSet
                            join ep in Context.Set<ExchangeProduct>()
                            on e.Id equals ep.ExchangeId
                            join p in Context.Set<Product>()
                            on ep.ProductId equals p.Id
                            where e.Date.Month == month
                            && e.ExchangeTypeId == (int)ExchangeTypeEnum.Compra
                            select ep.Quantity * p.SellPrice).Sum();

            return sells - expanses;
        }

        public DateTime GetProductLastExchange(int productId)
        {
            return (from e in DbSet
                    join ep in Context.Set<ExchangeProduct>()
                    on e.Id equals ep.ExchangeId
                    where ep.ProductId == productId
                    orderby e.Date descending
                    select e.Date).FirstOrDefault();
        }
    }
}
