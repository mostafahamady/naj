using Naj.Common;
using Naj.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Naj.Data
{
    public class NajUow : Uow<NajContext>
    {
        public NajUow()
        {
            base.DbContext = new NajContext();
            Configure(new RepositoryProvider(new RepositoryFactories(GetAppFactories())));
        }
        public NajUow(string ContextConnectionStringName)
        {
            if (!string.IsNullOrEmpty(ContextConnectionStringName))
                base.DbContext = new NajContext(ContextConnectionStringName);
            else
                base.DbContext = new NajContext();
            Configure(new RepositoryProvider(new RepositoryFactories(GetAppFactories())));
        }

        private IDictionary<Type, Func<DbContext, object>> GetAppFactories()
        {
            var appFactories = new Dictionary<Type, Func<DbContext, object>>();

            #region Baladi

            appFactories.Add(typeof(ITableRepository<RequestActivityType, Guid>), dbContext => new TableRepository<RequestActivityType, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<RequestSubmitterInfo, Guid>), dbContext => new TableRepository<RequestSubmitterInfo, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<VocationalRequest, Guid>), dbContext => new TableRepository<VocationalRequest, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<VocationalRequestActivityType, Guid>), dbContext => new TableRepository<VocationalRequestActivityType, Guid>(dbContext));

            #endregion

            #region Fee

            appFactories.Add(typeof(ITableRepository<Accomendation, Guid>), dbContext => new TableRepository<Accomendation, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Activity, Guid>), dbContext => new TableRepository<Activity, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ActivityType, Guid>), dbContext => new TableRepository<ActivityType, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<BuildingUsage, Guid>), dbContext => new TableRepository<BuildingUsage, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Duration, Guid>), dbContext => new TableRepository<Duration, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Item, Guid>), dbContext => new TableRepository<Item, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ItemOperation, Guid>), dbContext => new TableRepository<ItemOperation, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ItemType, Guid>), dbContext => new TableRepository<ItemType, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ItemValue, Guid>), dbContext => new TableRepository<ItemValue, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<MainActivity, Guid>), dbContext => new TableRepository<MainActivity, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Municipality, Guid>), dbContext => new TableRepository<Municipality, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Segement, Guid>), dbContext => new TableRepository<Segement, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ServiceClass, Guid>), dbContext => new TableRepository<ServiceClass, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ServiceRate, Guid>), dbContext => new TableRepository<ServiceRate, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<ServiceType, Guid>), dbContext => new TableRepository<ServiceType, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Slice, Guid>), dbContext => new TableRepository<Slice, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<SliceType, Guid>), dbContext => new TableRepository<SliceType, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Unit, Guid>), dbContext => new TableRepository<Unit, Guid>(dbContext));

            #endregion

            #region System

            appFactories.Add(typeof(ITableRepository<Module, Guid>), dbContext => new TableRepository<Module, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Menu, Guid>), dbContext => new TableRepository<Menu, Guid>(dbContext));
            appFactories.Add(typeof(ITableRepository<Page, Guid>), dbContext => new TableRepository<Page, Guid>(dbContext));

            #endregion

            return appFactories;
        }

        #region Baladi

        public ITableRepository<RequestActivityType, Guid> RequestActivityTypes { get { return GetStandardTableRepo<RequestActivityType, Guid>(); } }
        public ITableRepository<RequestSubmitterInfo, Guid> RequestSubmitterInfos { get { return GetStandardTableRepo<RequestSubmitterInfo, Guid>(); } }
        public ITableRepository<VocationalRequest, Guid> VocationalRequests { get { return GetStandardTableRepo<VocationalRequest, Guid>(); } }
        public ITableRepository<VocationalRequestActivityType,Guid> VocationalRequestActivityTypes { get { return GetStandardTableRepo<VocationalRequestActivityType, Guid>(); } }
        
        #endregion

        #region Fee

        public ITableRepository<Accomendation, Guid> Accomendations { get { return GetStandardTableRepo<Accomendation, Guid>(); } }
        public ITableRepository<Activity, Guid> Activities { get { return GetStandardTableRepo<Activity, Guid>(); } }
        public ITableRepository<ActivityType, Guid> ActivityTypes { get { return GetStandardTableRepo<ActivityType, Guid>(); } }
        public ITableRepository<BuildingUsage, Guid> BuildingUsages { get { return GetStandardTableRepo<BuildingUsage, Guid>(); } }
        public ITableRepository<Duration, Guid> Durations { get { return GetStandardTableRepo<Duration, Guid>(); } }
        public ITableRepository<Item, Guid> Items { get { return GetStandardTableRepo<Item, Guid>(); } }
        public ITableRepository<ItemOperation, Guid> ItemOperations { get { return GetStandardTableRepo<ItemOperation, Guid>(); } }
        public ITableRepository<ItemType, Guid> ItemTypes { get { return GetStandardTableRepo<ItemType, Guid>(); } }
        public ITableRepository<ItemValue, Guid> ItemValues { get { return GetStandardTableRepo<ItemValue, Guid>(); } }
        public ITableRepository<MainActivity, Guid> MainActivities { get { return GetStandardTableRepo<MainActivity, Guid>(); } }
        public ITableRepository<Municipality, Guid> Municipalities { get { return GetStandardTableRepo<Municipality, Guid>(); } }
        public ITableRepository<Segement, Guid> Segements { get { return GetStandardTableRepo<Segement, Guid>(); } }
        public ITableRepository<ServiceClass, Guid> ServiceClasses { get { return GetStandardTableRepo<ServiceClass, Guid>(); } }
        public ITableRepository<ServiceRate, Guid> ServiceRates { get { return GetStandardTableRepo<ServiceRate, Guid>(); } }
        public ITableRepository<ServiceType, Guid> ServiceTypes { get { return GetStandardTableRepo<ServiceType, Guid>(); } }
        public ITableRepository<Slice, Guid> Slices { get { return GetStandardTableRepo<Slice, Guid>(); } }
        public ITableRepository<SliceType, Guid> SliceTypes { get { return GetStandardTableRepo<SliceType, Guid>(); } }
        public ITableRepository<Unit, Guid> Units { get { return GetStandardTableRepo<Unit, Guid>(); } }

        #endregion

        #region System

        public ITableRepository<Module, Guid> Modules { get { return GetStandardTableRepo<Module, Guid>(); } }
        public ITableRepository<Menu, Guid> Menus { get { return GetStandardTableRepo<Menu, Guid>(); } }
        public ITableRepository<Page, Guid> Pages { get { return GetStandardTableRepo<Page, Guid>(); } }

        #endregion
    }
}
