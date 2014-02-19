using Cortoxa;
using Cortoxa.Data.Context;
using Cortoxa.Data.EntityFramework;
using Cortoxa.Data.Identity.Entitites;
using Cortoxa.Data.IoC;
using Cortoxa.Data.NHibernate;
using Cortoxa.Data.Repository;
using Cortoxa.NLog;
using Cortoxa.Owin;
using Cortoxa.Web.MVC;
using Cortoxa.Windsor;
using Owin;
using Samples.Data.NHibernate;

namespace Sampels.Web
{
    public partial class Startup
    {
        public void ConfigureContainer(IAppBuilder app)
        {
            app.UseContainer(x => x.UseWindsor())
                
                .InstallTool<IStoreSetup>(x => x.UseHibernate("Database", typeof (NHibernateSetup).Assembly))
//                .InstallTool<IStoreSetup>(x => x.UseHibernate("Database2", typeof(NHibernateSetup).Assembly))
                .InstallNLog("logger")
                .InstallControllers();

            var stores = app.Container().ResolveAll<IStore<IdentityUser>>();
        }
    }
}