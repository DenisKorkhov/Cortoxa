using Cortoxa;
using Cortoxa.Common.Log;
using Cortoxa.Container.Components;
using Cortoxa.Container.Extentions;
using Cortoxa.NLog;
using Cortoxa.Windsor;

namespace Samples.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            var container = Setup.Container(s => s.UseWindsor());
            var registrator = container.Register
                    .For<Test>(c => c.To<Test>())
               .Component(c=>c.NLog());

            var test = registrator.Resolve<Test>();
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

