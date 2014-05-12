using System.Reflection;
using System.Web.Mvc;
using Cortoxa;

using Cortoxa.Container.Component.Logging;
using Cortoxa.NLogger;
using Cortoxa.Web.MVC;
using Cortoxa.Web.MVC.Controllers;
using Cortoxa.Windsor;

namespace Samples.Web
{
    public class CortoxaConfig
    {
        public static void SetupContainer()
        {
            var container = Setup.Container(c => c.UseWindsor())
                .Register(r =>r.NLog())
                .Register(r => r.Controllers<Controller>().AssemblyCalling())
//                .Register(r => r
//                    .DataAccess(c => c
//                        .UseEnitityFramework<SamplesContext>().PerWebRequest().ConnectionString("DefaultConnection")
//                        .WithIdentity().User<IdentityUser>().Role<IdentityRole>()
//                        )

//                    .Repository("", LifeTime.Transient)
//                    .WithIdentity
//                    )
                ;

            container.InstallControllerFactory();
        }
    }
}