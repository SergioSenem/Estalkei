﻿using Core.Domain.Interfaces;
using Estalkei.Contracts.Dtos;

namespace Estalkei.Domain.Interfaces
{
    public interface IExchangeService : IServiceBase<ExchangeDto>
    {
        float GetMonthlyProfit(int month = 0);
    }
}
