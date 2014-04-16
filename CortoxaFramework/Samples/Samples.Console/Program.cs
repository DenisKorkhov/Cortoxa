using Cortoxa;
using Cortoxa.Common.Log;
using Cortoxa.Container.Component;
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
                .Register(r => r.Component(c=>c.NLog()))
//                .Register(r => r.Component() )
//                .Register(r => r.Component(c=>c.Controllers()))
//                .SetupControllerFactory()
                ;
                
             
//            var registration = container.Registration.For<Test>(c => c.To<Test>())
//               .Component(c=>c.NLog());

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

