using System.Data.Entity;

namespace Naj.Common.Intializers
{
    public class DropCreateDatabaseIfModelChangesInitializer<T> : DropCreateDatabaseIfModelChanges<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
        }
    }
}
