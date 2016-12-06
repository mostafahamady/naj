using System.Linq;
using Naj.Entity;
using Naj.Entity.Configuration;
using System.Data.Entity;

namespace Naj.Entity
{
    public class NajContext : DbContext
    {
        public NajContext()
            : this(ConnectionString: "NajDB") { }
        public NajContext(string ConnectionString)
            : base(nameOrConnectionString: ConnectionString) { Database.SetInitializer<NajContext>(null); }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Page> Pages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());;
        }
    }
}