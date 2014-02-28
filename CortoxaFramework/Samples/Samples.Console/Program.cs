using Cortoxa;
using Cortoxa.Components.Log;
using Cortoxa.Data.Component;
using Cortoxa.Data.EntityFramework;
using Cortoxa.IoC.Base;
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
            var container = Setup.InitContainer(x => x.UseWindsor())
                .Register
                    .Service(s => s.For<Test>().ToSelf().Name("test").Transient())
//                    .Component(c => c.NLog())
                    .Component(c => c.EntityDataSource<SamplesContext>()
                            .Configure(x => x.DbContext.LifeTime(LifeTime.Transient))
                            .Configure(x => x.DataSource.Name("db_datasource"))
                        );
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

