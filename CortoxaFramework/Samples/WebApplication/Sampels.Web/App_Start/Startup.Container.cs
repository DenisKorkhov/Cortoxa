using Cortoxa;
using Cortoxa.Data.IoC;
using Cortoxa.NHibernate;
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
                .InstallTool<IDataConfig>(x => x.UseHibernate("Database", typeof (NHibernateSetup).Assembly))
                .InstallNLog("logger")
                .InstallControllers();
        }
    }
}