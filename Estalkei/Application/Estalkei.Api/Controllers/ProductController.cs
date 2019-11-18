using Core.API.Base;
using Estalkei.Contracts.Dtos;
using Estalkei.Domain.Interfaces;

namespace Estalkei.Api.Controllers
{
    public class ProductController : ControllerCoreBase<ProductDto, IProductService>
    {
    }
}
