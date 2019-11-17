using Core.Data.Contexts;
using Core.Domain.Base;
using Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Data.Base
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : EntityBase
        where TContext: IContext
    {
        protected readonly TContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(IContext context)
        {
            Context = (TContext)context;
            DbSet = context.Set<TEntity>();
        }

        #region Get
        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.AsEnumerable();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetByIds(IEnumerable<int> ids)
        {
            return from e in DbSet
                   where ids.Contains(e.Id)
                   select e;
        }
        #endregion

        #region Add
        public virtual TEntity Add(TEntity newEntity)
        {
            return DbSet.Add(newEntity).Entity;
        }

        public virtual void AddRange(IEnumerable<TEntity> newEntities)
        {
            DbSet.AddRange(newEntities);
        }
        #endregion

        #region Update
        public virtual TEntity Update(TEntity entity)
        {
            return DbSet.Update(entity).Entity;

        }

        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            DbSet.UpdateRange(entities);
        }
        #endregion

        #region Delete
        public virtual TEntity Delete(int id)
        {
            var forDelete = DbSet.Find(id);
            return DbSet.Remove(forDelete).Entity;
        }

        public virtual void DeleteRange(IEnumerable<int> ids)
        {
            var forDelete = DbSet.Where(x => ids.Contains(x.Id));
            DbSet.RemoveRange(forDelete);
        }
        #endregion

        public virtual int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
