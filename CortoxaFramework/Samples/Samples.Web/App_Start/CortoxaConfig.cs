using System.Reflection;
using Cortoxa;
using Cortoxa.Windsor;
using Cortoxa.Web.MVC;

namespace Samples.Web
{
    public class CortoxaConfig
    {
        public static void SetupContainer()
        {
            var container = Setup.Container(c => c.UseWindsor())
                .Register(r => r.Controllers(Assembly.GetExecutingAssembly()))
                ;

            container.SetupControllerFactory();
        }
    }
}