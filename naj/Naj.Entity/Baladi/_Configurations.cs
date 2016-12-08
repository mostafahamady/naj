using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Naj.Entity
{
    #region RequestActivityType Configuration

    public class RequestActivityTypeConfiguration : EntityTypeConfiguration<RequestActivityType>
    {
        public RequestActivityTypeConfiguration()
        {
            HasMany(e => e.VocationalRequestActivityTypes).WithRequired(e => e.RequestActivityType).HasForeignKey(e => e.RequestActivityTypeId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region RequestSubmitterInfo Configuration

    public class RequestSubmitterInfoConfiguration : EntityTypeConfiguration<RequestSubmitterInfo>
    {
        public RequestSubmitterInfoConfiguration()
        {
            HasMany(e => e.VocationalRequests).WithRequired(e => e.RequestSubmitterInfo).HasForeignKey(e => e.RequestSubmitterInfoId).WillCascadeOnDelete(false);
        }
    }

    #endregion

    #region VocationalRequest Configuration

    public class VocationalRequestConfiguration : EntityTypeConfiguration<VocationalRequest>
    {
        public VocationalRequestConfiguration()
        {
            HasMany(e => e.VocationalRequestActivityTypes).WithRequired(e => e.VocationalRequest).HasForeignKey(e => e.VocationalRequestId).WillCascadeOnDelete(false);
        }
    }

    #endregion
}
