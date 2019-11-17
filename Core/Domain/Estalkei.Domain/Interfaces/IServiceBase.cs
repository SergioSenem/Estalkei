using Core.Contracts.Base;
using System.Collections.Generic;

namespace Core.Domain.Interfaces
{
    public interface IServiceBase<TEntityDto>
        where TEntityDto : DtoBase
    {
        IEnumerable<TEntityDto> GetAll();
        TEntityDto GetById(int id);
        IEnumerable<TEntityDto> GetByIds(IEnumerable<int> ids);

        TEntityDto Add(TEntityDto newEntity);
        void AddRange(IEnumerable<TEntityDto> newEntities);

        TEntityDto Update(TEntityDto entity);
        void UpdateRange(IEnumerable<TEntityDto> entity);

        TEntityDto Delete(int id);
        void DeleteRange(IEnumerable<int> ids);
    }
}
