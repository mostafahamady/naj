using System;
using System.Collections.Generic;
using System.Data.Entity;
using Naj.Common;
using Naj.Entity;

namespace Naj.Data
{
    public class RepositoryFactories
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _repositoryFactories;

        public RepositoryFactories()
        {
            _repositoryFactories = GetAppFactories();
        }

        public RepositoryFactories(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _repositoryFactories = factories;
        }

        private IDictionary<Type, Func<DbContext, object>> GetAppFactories()
        {
            return new Dictionary<Type, Func<DbContext, object>>
            {
               {typeof(ITableRepository<Module,Guid>), dbContext => new TableRepository<Module,Guid>(dbContext)},
                {typeof(ITableRepository<Menu,Guid>), dbContext => new TableRepository<Menu,Guid>(dbContext)},
                {typeof(ITableRepository<Page,Guid>), dbContext => new TableRepository<Page,Guid>(dbContext)},
            };
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
