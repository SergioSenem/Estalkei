using Core.Domain.Interfaces;
using Estalkei.Domain.Entities;
using System;

namespace Estalkei.Domain.Interfaces
{
    public interface IExchangeRepository : IRepositoryBase<Exchange>
    {
        float GetMonthProfit(int month);
        DateTime GetProductLastExchange(int productId);
    }
}
