using System;
using System.Data.Entity;

namespace Naj.Common
{
    public interface IRepositoryProvider
    {
        DbContext DbContext { get; set; }
        IViewRepository<TEntity> GetViewRepositoryForEntityType<TEntity>()
            where TEntity : class;
        ITableRepository<TEntity, TKey> GetTableRepositoryForEntityType<TEntity, TKey>()
            where TEntity : class,IEntity<TKey>
            where TKey : IComparable<TKey>;
        T GetRepository<T>(Func<DbContext, object> factory = null) where T : class;
    }
}
