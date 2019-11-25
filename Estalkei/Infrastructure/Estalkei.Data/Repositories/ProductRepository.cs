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
    public class ProductRepository : RepositoryBase<Product, EstalkeiContext>, IProductRepository
    {
        public ProductRepository(IContext context) : base(context)
        {

        }

        public IEnumerable<Product> GetNotSoldInMonths(int months)
        {
            return from p in DbSet
                   where (
                        from ep in Context.Set<ExchangeProduct>()
                        join e in Context.Set<Exchange>()
                        on ep.ExchangeId equals e.Id
                        where ep.ProductId == p.Id
                        && e.Date >= DateTime.Now.AddMonths(months * -1)
                        select e
                   ).Count() == 0
                   select p;
        }

        public override Product Add(Product newEntity)
        {
            using(var transaction = Context.Database.BeginTransaction())
            {
                var product = DbSet.Add(newEntity).Entity;
                Context.SaveChanges();

                var exchange = new Exchange() { ExchangeTypeId = (int)ExchangeTypeEnum.Compra, Date = DateTime.Now };
                exchange = Context.Set<Exchange>().Add(exchange).Entity;
                Context.SaveChanges();

                var exchangeProduct = new ExchangeProduct() { ExchangeId = exchange.Id, ProductId = product.Id, Quantity = product.Quantity };
                exchangeProduct = Context.Set<ExchangeProduct>().Add(exchangeProduct).Entity;
                Context.SaveChanges();

                transaction.Commit();

                return product;
            }
        }
    }
}
