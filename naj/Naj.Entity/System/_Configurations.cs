using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Naj.Entity
{
    #region Module Configuration
    public class ModuleConfiguration : EntityTypeConfiguration<Module>
    {
        public ModuleConfiguration()
        {
            HasMany(e => e.Menus).WithRequired(e => e.Module).HasForeignKey(e => e.ModuleID).WillCascadeOnDelete(false);
        }
    }
    #endregion

    #region Menu Configuration
    public class MenuConfiguration : EntityTypeConfiguration<Menu>
    {
        public MenuConfiguration()
        {
            HasMany(e => e.Pages).WithRequired(e => e.Menu).HasForeignKey(e => e.MenuID).WillCascadeOnDelete(false);
        }
    }
    #endregion
}
