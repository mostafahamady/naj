using System.Data.Entity;

namespace Naj.Common.Intializers
{
    public class CreateDatabaseIfNotExistsInitializer<T> : CreateDatabaseIfNotExists<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
        }
    }
}
