using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Sampels.Web.Startup))]
namespace Sampels.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureContainer(app);
            ConfigureAuth(app);
        }
    }
}
