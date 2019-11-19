using Core.Domain.Interfaces;
using Estalkei.Domain.Entities;

namespace Estalkei.Domain.Interfaces
{
    public interface IExchangeRepository : IRepositoryBase<Exchange>
    {
        float GetMonthProfit(int month);
    }
}
