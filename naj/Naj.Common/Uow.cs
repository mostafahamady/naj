using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Naj.Common
{
    public abstract class Uow<TContext> : IDisposable where TContext : DbContext
    {
        protected TContext DbContext { get; set; }

        public void CommitAll()
        {
            DbContext.SaveChanges();
        }

        public async Task CommitAllAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        protected void Configure(IRepositoryProvider repositoryProvider)
        {
            ConfigureDbContext();
            repositoryProvider.DbContext = DbContext;
            RepositoryProvider = repositoryProvider;
        }
        private void ConfigureDbContext()
        {
            // Do Not Enable proxied entities, else serialization fails
            //DbContext.Configuration.ProxyCreationEnabled = true;

            // Load navigation properties explicity ( avoid serialization trouble)
            //DbContext.Configuration.LazyLoadingEnabled = true;

            //DbContext.Configuration.ValidateOnSaveEnabled = true;
        }

        protected IRepositoryProvider RepositoryProvider { get; set; }
        protected IViewRepository<TEntity> GetStandardViewRepo<TEntity>()
            where TEntity : class
        {
            return RepositoryProvider.GetViewRepositoryForEntityType<TEntity>();
        }
        protected ITableRepository<TEntity, TKey> GetStandardTableRepo<TEntity, TKey>()
            where TEntity : class,IEntity<TKey>
            where TKey : IComparable<TKey>
        {
            return RepositoryProvider.GetTableRepositoryForEntityType<TEntity, TKey>();
        }
        protected T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (DbContext != null)
                {
                    DbContext.Dispose();
                }
            }
        }

        #endregion
    }
}
