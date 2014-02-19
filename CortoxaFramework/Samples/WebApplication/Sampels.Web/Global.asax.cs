using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Cortoxa;
using Cortoxa.Data.IoC;
using Cortoxa.IoC;
using Cortoxa.IoC.Attributes;
using Cortoxa.NLog;
using Cortoxa.Web.MVC;
using Cortoxa.Windsor;
using Samples.Data.NHibernate;

namespace Sampels.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
