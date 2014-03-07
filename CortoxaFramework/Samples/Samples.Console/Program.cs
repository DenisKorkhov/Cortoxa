using Cortoxa;
using Cortoxa.Components.Log;
using Cortoxa.IoC.Base;
using Cortoxa.IoC.Extentions;
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
//                .Register(r => r.Component(c => c.NLog()))
                ;
//                .Register(r => r.t);

            var instance = container.Resolve<Test>();
            instance.DoSomthing();

//                .Register(r => r.For<Test>().ToSelf().Name("test").Transient())
//
//                .Register(r=>r.Service<T>.fo);

////                    .Component(c => c.NLog())
//                    .Component(c => c.EntityDataSource<SamplesContext>()
//                            .Configure(x => x.DbContext.LifeTime(LifeTime.Transient))
//                            .Configure(x => x.DataSource.Name("db_datasource"))
//                        );
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

