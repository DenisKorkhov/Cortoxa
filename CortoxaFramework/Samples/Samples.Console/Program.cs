using Cortoxa;
using Cortoxa.Components.Log;
using Cortoxa.Data.Component;
using Cortoxa.Data.EntityFramework;
using Cortoxa.IoC.Service;
using Cortoxa.NLog;
using Cortoxa.Windsor;
using Samples.Data.EntityFramework.Context;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.InitContainer2(x => x.UseWindsor())
                .Register(s => s.For<Test>().ToSelf().Name("test").Transient())
                .Register<ILoggerComponent>(c => c.NLog("Test"))
                .Register<IDataComponent>(c => c.EntityDataSource<SamplesContext>());

            var t = container.Resolve.One<Test>();
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

        public virtual void DoSomthing()
        {
            logger.Debug("Do something");
        }
    }
}

