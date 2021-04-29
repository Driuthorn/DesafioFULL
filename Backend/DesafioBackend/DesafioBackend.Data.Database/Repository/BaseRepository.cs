using DesafioBackend.Data.Database.Context;
using DesafioBackend.Data.Database.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DesafioBackend.Data.Database.Repository
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DesafioBackendContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public BaseRepository(DesafioBackendContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public TEntity Get(Guid id) => _dbSet.Find(id);
        public IQueryable<TEntity> Get() => _dbSet;
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _dbSet.Where(predicate);
        public int SaveChanges() => _context.SaveChanges();
    }
}
