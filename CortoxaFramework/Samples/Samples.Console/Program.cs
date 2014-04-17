using Cortoxa;
using Cortoxa.Common.Log;
using Cortoxa.Container.Component;
using Cortoxa.Container.Component.Logging;
using Cortoxa.Container.Extentions;
using Cortoxa.NLog;
using Cortoxa.Windsor;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.Container(s => s.UseWindsor())
                .Register(r => r.For<Test>().To<Test>())
                .Register(r => r.Logger(c=>c.UseNLog()))
                ;

            var test = container.Resolver.Resolve<Test>();
            test.DoSomthing();
        }
    }
    
    public class Test
    {
        private readonly ILogger logger;

        public Test(ILogger logger)
        {
            this.logger = logger;
        }

        public virtual void DoSomthing()
        {
            logger.Info("Do something!");
        }
    }
}

