using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebScanner.Models.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : DbEntity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
