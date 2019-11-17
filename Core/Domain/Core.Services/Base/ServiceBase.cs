using AutoMapper;
using Core.Contracts.Base;
using Core.Domain.Base;
using Core.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services.Base
{
    public abstract class ServiceBase<TEntityDto, TEntity, TRepository> : IServiceBase<TEntityDto>
        where TEntityDto : DtoBase
        where TEntity : EntityBase
        where TRepository : IRepositoryBase<TEntity>
    {
        protected readonly TRepository Repository;
        protected readonly IMapper Mapper;

        public ServiceBase(TRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        #region Get
        public virtual IEnumerable<TEntityDto> GetAll()
        {
            var retorno = Repository.GetAll().Select(Mapper.Map<TEntityDto>);
            return retorno;
        }

        public virtual TEntityDto GetById(int id)
        {
            return Mapper.Map<TEntityDto>(Repository.GetById(id));
        }

        public virtual IEnumerable<TEntityDto> GetByIds(IEnumerable<int> ids)
        {
            return Mapper.Map<IEnumerable<TEntityDto>>(Repository.GetByIds(ids));
        }
        #endregion

        #region Add
        public virtual TEntityDto Add(TEntityDto newEntity)
        {
            var retorno = Repository.Add(Mapper.Map<TEntity>(newEntity));
            Repository.SaveChanges();
            return Mapper.Map<TEntityDto>(retorno);
        }

        public virtual void AddRange(IEnumerable<TEntityDto> newEntities)
        {
            Repository.AddRange(Mapper.Map<IEnumerable<TEntity>>(newEntities));
            Repository.SaveChanges();
        }
        #endregion

        #region Update
        public virtual TEntityDto Update(TEntityDto entity)
        {
            var retorno = Repository.Update(Mapper.Map<TEntity>(entity));
            Repository.SaveChanges();
            return Mapper.Map<TEntityDto>(retorno);
        }

        public virtual void UpdateRange(IEnumerable<TEntityDto> entities)
        {
            Repository.UpdateRange(Mapper.Map<IEnumerable<TEntity>>(entities));
            Repository.SaveChanges();
        }
        #endregion

        #region Delete
        public virtual TEntityDto Delete(int id)
        {
            var retorno = Repository.Delete(id);
            Repository.SaveChanges();
            return Mapper.Map<TEntityDto>(retorno);
        }

        public virtual void DeleteRange(IEnumerable<int> ids)
        {
            Repository.DeleteRange(ids);
            Repository.SaveChanges();
        }
        #endregion
    }
}
