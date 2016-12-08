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

        IQueryable<TEntity> Search(string PropertyValue);
    }

    public interface ITableRepository<TEntity, TKey> : IViewRepository<TEntity>
        where TEntity : class,IEntity<TKey>
        where TKey : IComparable<TKey>
    {
        TEntity GetById(TKey Id);

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(TKey Id);

        void Commit();

        dynamic MaxId();
    }
}
