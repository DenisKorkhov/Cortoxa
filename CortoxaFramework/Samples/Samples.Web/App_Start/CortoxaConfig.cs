using System.Reflection;
using Cortoxa;
using Cortoxa.Container.Component;
using Cortoxa.Container.Component.Logging;
using Cortoxa.Container.Life;
using Cortoxa.Data.Components;
using Cortoxa.Data.EntityFramework;
using Cortoxa.Data.Identity.Components;
using Cortoxa.NLog;
using Cortoxa.Windsor;
using Cortoxa.Web.MVC;
using Samples.Data.EntityFramework.Context;

namespace Samples.Web
{
    public class CortoxaConfig
    {
        public static void SetupContainer()
        {
            var container = Setup.Container(c => c.UseWindsor())
                .Register(r =>r.Logger(c=>c.UseNLog()))
                .Register(r => r.Controllers(Assembly.GetExecutingAssembly()))
//                .Register(r => r
//                    .DataAccess(c => c
//                        .UseEnitityFramework<SamplesContext>().PerWebRequest().ConnectionString("DefaultConnection")
//                        .WithIdentity().User<IdentityUser>().Role<IdentityRole>()
//                        )

//                    .Repository("", LifeTime.Transient)
//                    .WithIdentity
//                    )
                ;

            container.SetupControllerFactory();
        }
    }
}