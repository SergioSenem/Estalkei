using Core.Domain.Base;
using System.Collections.Generic;

namespace Core.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity>
        where TEntity : EntityBase
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetByIds(IEnumerable<int> ids);

        TEntity Add(TEntity newEntity);
        void AddRange(IEnumerable<TEntity> newEntities);

        TEntity Delete(int id);
        void DeleteRange(IEnumerable<int> ids);

        TEntity Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        int SaveChanges();
    }
}
