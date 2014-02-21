using Cortoxa;
using Cortoxa.Windsor;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.InitContainer2(x => x.UseWindsor())
                .Register.Service<Test>(s => s.ToSelf().Name("test"));


//                .InstallNLog("logger")
//                .Register<IWindsorContainer>(c => c.Register(Component.Service<Test>().LifestyleTransient()));
//            var t = container.Resolve.One<Test>();
//            t.DoSomthing();
        }
        
    }
    public class Test
    {
//        private readonly ILogger logger;
//
//        public Test(ILogger logger)
//        {
//            this.logger = logger;
//        }

        public void DoSomthing()
        {
//            logger.Info("test message");
        }
    }
}
