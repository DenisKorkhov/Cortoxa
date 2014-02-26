using Cortoxa;
using Cortoxa.Components.Log;
using Cortoxa.Data.Component;
using Cortoxa.Data.EntityFramework;
using Cortoxa.Data.EntityFramework.Data;
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
            var container = Setup.InitContainer2(x => x.UseWindsor());

            container.Register.Service<Test>(s => s.ToSelf().Name("test").Transient());
            container.Register.Component<ILogger>(c => c.NLog("Logger"));
            container.Register.Component<IDataSource>(c => c.EntityDataSource<SamplesContext>());


            var dataSource = container.Resolve.One<IDataSource>();
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
