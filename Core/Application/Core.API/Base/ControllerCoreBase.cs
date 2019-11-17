using Core.Contracts.Base;
using Core.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Core.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCoreBase<TEntityDto, TService>: ControllerBase
        where TEntityDto : DtoBase
        where TService : IServiceBase<TEntityDto>
    {
        [HttpGet]
        public IEnumerable<TEntityDto> Get([FromServices] TService service)
        {
            return service.GetAll();
        }

        [Route("{id}")]
        [HttpGet]
        public TEntityDto GetByid([FromServices] TService service, int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public TEntityDto Post([FromServices] TService service, TEntityDto newEntity)
        {
            return service.Add(newEntity);
        }

        [Route("Bulk")]
        [HttpPost]
        public void PostMany([FromServices] TService service, IEnumerable<TEntityDto> newEntity)
        {
            service.AddRange(newEntity);
        }

        [HttpPut]
        public TEntityDto Put([FromServices] TService service, TEntityDto entity)
        {
            return service.Update(entity);
        }

        [Route("Bulk")]
        [HttpPut]
        public void PutMany([FromServices] TService service, IEnumerable<TEntityDto> entities)
        {
            service.UpdateRange(entities);
        }

        [Route("{id}")]
        [HttpDelete]
        public TEntityDto Delete([FromServices] TService service, int id)
        {
            return service.Delete(id);
        }
    }
}
