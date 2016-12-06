using System;
using System.Data.Entity;
using System.Linq;

namespace Naj.Common
{
    public interface IViewRepository<TEntity> : IDisposable
        where TEntity : class
    {
        DbSet<TEntity> GetAll();

        IQueryable<TEntity> Filter<TProperty>(string PropertyName, TProperty PropertyValue);
    }

    public interface ITableRepository<TEntity, TKey> : IViewRepository<TEntity>
        where TEntity : class,IEntity<TKey>
        where TKey : IComparable<TKey>
    {
        TEntity GetByID(TKey ID);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey ID);

        void Commit();

        dynamic MaxID();
    }
}
