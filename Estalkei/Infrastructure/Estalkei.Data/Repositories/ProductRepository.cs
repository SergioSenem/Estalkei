using Core.Data.Base;
using Core.Data.Contexts;
using Estalkei.Contracts.Enums;
using Estalkei.Data.Contexts;
using Estalkei.Domain.Entities;
using Estalkei.Domain.Interfaces;
using System;

namespace Estalkei.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, EstalkeiContext>, IProductRepository
    {
        public ProductRepository(IContext context) : base(context)
        {

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
