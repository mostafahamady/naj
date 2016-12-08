using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Naj.Entity
{
    #region ActivityType Configuration
    public class ActivityTypeConfiguration : EntityTypeConfiguration<ActivityType>
    {
        public ActivityTypeConfiguration()
        {
            HasMany(e => e.Activities).WithRequired(e => e.ActivityType).HasForeignKey(e => e.ActivityTypeId).WillCascadeOnDelete(false);
        }
    }
    #endregion

    #region Duration Configuration

    public class DurationConfiguration : EntityTypeConfiguration<Duration>
    {
        public DurationConfiguration()
        {
            HasMany(e => e.ItemValues).WithRequired(e => e.Duration_).HasForeignKey(e => e.DurationId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region Item Configuration

    public class ItemConfiguration : EntityTypeConfiguration<Item>
    {
        public ItemConfiguration()
        {
            HasMany(e => e.ItemValues).WithRequired(e => e.Item).HasForeignKey(e => e.ItemId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region ItemType Configuration

    public class ItemTypeConfiguration : EntityTypeConfiguration<ItemType>
    {
        public ItemTypeConfiguration()
        {
            HasMany(e => e.Items).WithRequired(e => e.ItemType).HasForeignKey(e => e.ItemTypeId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region MainActivity Configuration

    public class MainActivityConfiguration : EntityTypeConfiguration<MainActivity>
    {
        public MainActivityConfiguration()
        {
            HasMany(e => e.Activities).WithRequired(e => e.MainActivity).HasForeignKey(e => e.MainActivityId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region Segement Configuration

    public class SegementConfiguration : EntityTypeConfiguration<Segement>
    {
        public SegementConfiguration()
        {
            HasMany(e => e.Municipalities).WithRequired(e => e.Segement).HasForeignKey(e => e.SegementId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region ServiceClass Configuration

    public class ServiceClassConfiguration : EntityTypeConfiguration<ServiceClass>
    {
        public ServiceClassConfiguration()
        {
            HasMany(e => e.Accomendations).WithRequired(e => e.ServiceClass).HasForeignKey(e => e.ServiceClassId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region ServiceRate Configuration

    public class ServiceRateConfiguration : EntityTypeConfiguration<ServiceRate>
    {
        public ServiceRateConfiguration()
        {
            HasMany(e => e.Accomendations).WithRequired(e => e.ServiceRate).HasForeignKey(e => e.ServiceRateId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region ServiceType Configuration

    public class ServiceTypeConfiguration : EntityTypeConfiguration<ServiceType>
    {
        public ServiceTypeConfiguration()
        {
            HasMany(e => e.Accomendations).WithRequired(e => e.ServiceType).HasForeignKey(e => e.ServiceTypeId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region Unit Configuration

    public class UnitConfiguration : EntityTypeConfiguration<Unit>
    {
        public UnitConfiguration()
        {
            HasMany(e => e.Slices).WithRequired(e => e.Unit).HasForeignKey(e => e.UnitId).WillCascadeOnDelete(false);
        }
    }

    #endregion
}
