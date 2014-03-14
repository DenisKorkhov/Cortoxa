using Cortoxa;
using Cortoxa.Common;
using Cortoxa.Common.Log;
using Cortoxa.Container.Common;
using Cortoxa.Container.Components;
using Cortoxa.Container.Services;
using Cortoxa.Data.EntityFramework;
using Cortoxa.NLog;
using Cortoxa.Windsor;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.Container(s => s.UseWindsor())
                .Register(r => r.For<Test>().To<Test>().Name("test").LifeTime(LifeTime.Transient))
                .Register(r => r.Component(c => c.Nlog().Update(x=>x.Logger.Name("logger_name"))))
                .Register(r => r.Component(c => c.EntityFramework()))
                ;


            var test = container.Resolve<Test>();
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
            logger.Debug("Do something");
        }
    }
}

