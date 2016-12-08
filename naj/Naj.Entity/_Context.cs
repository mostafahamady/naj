using System.Linq;
using Naj.Entity;
using System.Data.Entity;

namespace Naj.Entity
{
    public class NajContext : DbContext
    {
        public NajContext()
            : this(ConnectionString: "NajDB") { }
        public NajContext(string ConnectionString)
            : base(nameOrConnectionString: ConnectionString) { Database.SetInitializer<NajContext>(null); }

        #region  Baladi

        public virtual DbSet<RequestActivityType> RequestActivityType { get; set; }
        public virtual DbSet<RequestSubmitterInfo> RequestSubmitterInfo { get; set; }
        public virtual DbSet<VocationalRequest> VocationalRequest { get; set; }
        public virtual DbSet<VocationalRequestActivityType> VocationalRequestActivityType { get; set; }
        
        #endregion

        #region Fee
        public virtual DbSet<Accomendation> Accomendation { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<BuildingUsage> BuildingUsage { get; set; }
        public virtual DbSet<Duration> Duration { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<ItemOperation> ItemOperation { get; set; }
        public virtual DbSet<ItemType> ItemType { get; set; }
        public virtual DbSet<ItemValue> ItemValue { get; set; }
        public virtual DbSet<MainActivity> MainActivity { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<Segement> Segement { get; set; }
        public virtual DbSet<ServiceClass> ServiceClass { get; set; }
        public virtual DbSet<ServiceRate> ServiceRate { get; set; }
        public virtual DbSet<ServiceType> ServiceType { get; set; }
        public virtual DbSet<Slice> Slice { get; set; }
        public virtual DbSet<SliceType> SliceType { get; set; }
        public virtual DbSet<Unit> Unit { get; set; }

        #endregion

        #region System

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Page> Pages { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region  Baladi

            modelBuilder.Configurations.Add(new RequestActivityTypeConfiguration());
            modelBuilder.Configurations.Add(new RequestSubmitterInfoConfiguration());
            modelBuilder.Configurations.Add(new VocationalRequestConfiguration());

            #endregion

            #region Fee

            modelBuilder.Configurations.Add(new ActivityTypeConfiguration());
            modelBuilder.Configurations.Add(new DurationConfiguration());
            modelBuilder.Configurations.Add(new ItemConfiguration());
            modelBuilder.Configurations.Add(new ItemTypeConfiguration());
            modelBuilder.Configurations.Add(new MainActivityConfiguration());
            modelBuilder.Configurations.Add(new SegementConfiguration());
            modelBuilder.Configurations.Add(new ServiceClassConfiguration());
            modelBuilder.Configurations.Add(new ServiceRateConfiguration());
            modelBuilder.Configurations.Add(new ServiceTypeConfiguration());
            modelBuilder.Configurations.Add(new UnitConfiguration());

            #endregion

            #region System

            modelBuilder.Configurations.Add(new ModuleConfiguration());
            modelBuilder.Configurations.Add(new MenuConfiguration());

            #endregion
        }
    }
}