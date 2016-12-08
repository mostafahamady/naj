using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;

namespace Naj.Common
{
    public class TableRepository<TEntity, TKey> : ViewRepository<TEntity>, ITableRepository<TEntity, TKey>
        where TEntity : class,IEntity<TKey>
        where TKey : IComparable<TKey>
    {
        public TableRepository(DbContext dbContext) : base(dbContext) { }

        public virtual TEntity GetById(TKey Id)
        {
            return DbSet.Find(Id);
        }

        public virtual void Add(TEntity entity)
        {
            PropertyInfo prop = typeof(TEntity).GetProperty("Id");
            List<Attribute> attrs = prop.GetCustomAttributes().ToList<Attribute>();

            foreach (var attr in attrs)
                if (attr is DatabaseGeneratedAttribute)
                    if (((DatabaseGeneratedAttribute)attr).DatabaseGeneratedOption == DatabaseGeneratedOption.None)
                        if (prop.GetType() == typeof(Guid))
                            if ((Guid)(object)entity.Id == Guid.Empty)
                                entity.Id = (TKey)(object)Guid.NewGuid();
                        else
                            entity.Id = MaxId() + 1;

            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;
            else
                DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State == EntityState.Detached)
                DbSet.Attach(entity);
            dbEntityEntry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
                dbEntityEntry.State = EntityState.Deleted;
            else
            {
                DbSet.Attach(entity);
                DbSet.Remove(entity);
            }
        }

        public virtual void Delete(TKey Id)
        {
            var entity = GetById(Id);
            if (entity == null) return; // not found
            Delete(entity);
        }

        public void Commit()
        {
            DbContext.SaveChanges<TEntity>();
        }

        public dynamic MaxId()
        {
            return DbSet.OrderByDescending(e=>e.Id).Select(e=>e.Id).FirstOrDefault();
        }
    }
}
