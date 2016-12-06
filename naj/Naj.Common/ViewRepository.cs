using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Naj.Common;

namespace Naj.Common
{
    public class ViewRepository<TEntity> : IViewRepository<TEntity>
        where TEntity : class
    {
        public ViewRepository(DbContext dbContext)
        {
            if (dbContext == null)
                throw new ArgumentNullException("dbContext");
            DbContext = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        protected DbContext DbContext { get; set; }
        protected DbSet<TEntity> DbSet { get; set; }

        public virtual DbSet<TEntity> GetAll()
        {
            return DbSet;
        }

        public IQueryable<TEntity> Filter<TProperty>(string PropertyName, TProperty PropertyValue)
        {
            Expression<Func<TEntity, bool>> predicate = LinqExpression.EqualExpression<TEntity, TProperty>(PropertyName, PropertyValue);
            return DbSet.Where<TEntity>(predicate);
        }

        public void Dispose()
        {
            this.DbContext.Dispose();
        }
    }
}
