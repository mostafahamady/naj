using Naj.Common;
using Naj.Entity;
using System;

namespace Naj.Data
{
    #region Interface
    public interface INajUow
    {
        ITableRepository<Module, Guid> Modules { get; }
        ITableRepository<Menu, Guid> Menus { get; }
        ITableRepository<Page, Guid> Pages { get; }
    }
    #endregion

    #region Class
    public class NajUow : Uow<NajContext>, INajUow
    {
        public NajUow(IRepositoryProvider repositoryProvider)
        {
            base.DbContext = new NajContext();
            Configure(repositoryProvider);
        }
        public NajUow(IRepositoryProvider repositoryProvider, string ContextConnectionStringName)
        {
            if (!string.IsNullOrEmpty(ContextConnectionStringName))
                base.DbContext = new NajContext(ContextConnectionStringName);
            else
                base.DbContext = new NajContext();
            Configure(repositoryProvider);
        }

        public ITableRepository<Module, Guid> Modules { get { return GetStandardTableRepo<Module, Guid>(); } }
        public ITableRepository<Menu, Guid> Menus { get { return GetStandardTableRepo<Menu, Guid>(); } }
        public ITableRepository<Page, Guid> Pages { get { return GetStandardTableRepo<Page, Guid>(); } }
    }
    #endregion
}
