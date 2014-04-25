using System.Linq;
using Cortoxa;
using Cortoxa.Common.Log;
using Cortoxa.Container.Component;
using Cortoxa.Container.Component.Logging;
using Cortoxa.Container.Extentions;
using Cortoxa.Data.Common;
using Cortoxa.Data.Components;
using Cortoxa.Data.EntityFramework;
using Cortoxa.Data.EntityFramework.Component;
using Cortoxa.Data.Identity.Components;
using Cortoxa.NLog;
using Cortoxa.Windsor;
using Samples.Data.Entities;
using Samples.Data.EntityFramework.Context;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.Container(s => s.UseWindsor())
                .Register(r => r.For<Test>().To<Test>())
                .Register(r => r.Logger(c =>c.UseNLog()))
                .Register(r => r.DataSource(c => c
                                    .UseEnitityFramework().Context<SamplesContext>().ConnectionString("Database").PerThread()
                                    .WithIdentity().User<User>().Role<Role>()
                                )
                        );

            var test = container.Resolver.Resolve<Test>();
            test.DoSomthing();
        }
    }
    
    public class Test
    {
        private readonly ILogger logger;
        private readonly IDataSource dataSource;
//        private readonly IStore<User> userStore;

        public Test(ILogger logger, IDataSource dataSource/*, IStore<User> userStore*/)
        {
            this.logger = logger;
            this.dataSource = dataSource;
//            this.userStore = userStore;
        }

        public virtual void DoSomthing()
        {
            logger.Info("Do something!");

            var user = new User {Name = "aaa"};
            this.dataSource.Add(user);
            this.dataSource.SaveChanges();
            user = this.dataSource.Query<User>().First();
            this.dataSource.Delete(user);
            this.dataSource.SaveChanges();

            //
//            this.userStore.Add(new User { Name = "User1" });
//            this.userStore.SaveChanges();
//            var user2 = this.userStore.First(x => x.Name == "User1");
//            this.userStore.Delete(user2);
//            this.userStore.SaveChanges();
        }
    }
}

