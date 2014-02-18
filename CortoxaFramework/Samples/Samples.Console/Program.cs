using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Cortoxa;
using Cortoxa.Common.Log;
using Cortoxa.NLog;
using Cortoxa.Windsor;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.InitContainer(x => x.UseWindsor())
                .InstallNLog("logger")
                .Register<IWindsorContainer>(c => c.Register(Component.For<Test>().LifestyleTransient()));
            var t = container.Resolve<Test>();
            t.DoSomthing();
        }
        
    }
    public class Test
    {
        private readonly ILogger logger;

        public Test(ILogger logger)
        {
            this.logger = logger;
        }

        public void DoSomthing()
        {
            logger.Info("test message");
        }
    }
}
