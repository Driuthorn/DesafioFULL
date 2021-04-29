using System;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioBackend.Data.Database.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity obj);
        TEntity Get(Guid id);
        IQueryable<TEntity> Get();
        int SaveChanges();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
