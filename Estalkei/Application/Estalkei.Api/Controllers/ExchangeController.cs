using Core.API.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Estalkei.Api.Controllers
{
    public class ExchangeController : ControllerCoreBase<ExchangeDto, IExchangeService>
    {
        [HttpGet]
        [Route("[action]")]
        public float GetMonthProfit([FromServices] IExchangeService service, [FromQuery] int month = 0)
        {
            return service.GetMonthlyProfit(month);
        }
    }
}
