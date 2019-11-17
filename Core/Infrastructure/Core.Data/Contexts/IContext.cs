using Microsoft.EntityFrameworkCore;
using System;

namespace Core.Data.Contexts
{
    public interface IContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        int SaveChanges();
    }
}
