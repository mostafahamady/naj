using System.Data.Entity;

namespace Naj.Common.Intializers
{
    public class DropCreateDatabaseAlwaysInitializer<T> : DropCreateDatabaseAlways<T> where T : DbContext
    {
        protected override void Seed(T context)
        {
        }
    }
}
