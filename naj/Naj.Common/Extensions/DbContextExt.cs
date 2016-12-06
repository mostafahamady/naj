using System.Linq;
using System.Data.Entity;

namespace Naj.Common
{
    public static class DbContextExtension
    {
        public static int SaveChanges<TEntity>(this DbContext dbContext)
           where TEntity : class
        {
            var original = dbContext.ChangeTracker.Entries()
                        .Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType()) && x.State != EntityState.Unchanged)
                        .GroupBy(x => x.State)
                        .ToList();

            foreach (var entry in dbContext.ChangeTracker.Entries().Where(x => !typeof(TEntity).IsAssignableFrom(x.Entity.GetType())))
                entry.State = EntityState.Unchanged;

            var rows = dbContext.SaveChanges();

            foreach (var state in original)
                foreach (var entry in state)
                    entry.State = state.Key;

            return rows;
        }
    }
}
