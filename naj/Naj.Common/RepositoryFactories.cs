using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Naj.Common
{
    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<TRepository>()
        {
            Func<DbContext, object> factory;
            _repositoryFactories.TryGetValue(typeof(TRepository), out factory);
            return factory;
        }

        public Func<DbContext, object> GetViewRepositoryFactoryForEntityType<TRepository, TEntity>()
            where TEntity : class
        {
            return GetRepositoryFactory<TRepository>() ?? DefaultViewRepositoryFactory<TEntity>();
        }
        public Func<DbContext, object> GetTableRepositoryFactoryForEntityType<TRepository, TEntity, TKey>()
            where TEntity : class,IEntity<TKey>
            where TKey : IComparable<TKey>
        {
            return GetRepositoryFactory<TRepository>() ?? DefaultTableRepositoryFactory<TEntity,TKey>();
        }

        protected virtual Func<DbContext, object> DefaultViewRepositoryFactory<TEntity>()
            where TEntity : class

        {
            return dbContext => new ViewRepository<TEntity>(dbContext);
        }
        protected virtual Func<DbContext, object> DefaultTableRepositoryFactory<TEntity, TKey>()
            where TEntity : class,IEntity<TKey>
            where TKey : IComparable<TKey>
        {
            return dbContext => new TableRepository<TEntity, TKey>(dbContext);
        }
    }
}
