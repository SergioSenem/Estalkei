using Core.API.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Estalkei.Api.Controllers
{
    public class ProductController : ControllerCoreBase<ProductDto, IProductService>
    {
        [HttpGet("[action]")]
        public IEnumerable<ProductDto> GetNotSoldInMonths([FromServices] IProductService service, [FromQuery] int months = 2)
        {
            return service.GetNotSoldInMonths(months);
        }
    }
}
