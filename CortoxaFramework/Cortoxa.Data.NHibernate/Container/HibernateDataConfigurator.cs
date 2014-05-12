using System;
using Cortoxa.Configuration;

namespace Cortoxa.Data.NHibernate.Container
{
    public class HibernateDataConfigurator : IConfigurator<HibernateDataContext>, IConfiguratorBuilder<HibernateDataContext>
    {
        public void Setup(Action<Action<HibernateDataContext>> contextAction)
        {
            throw new NotImplementedException();
        }

        public void Configure(Action<HibernateDataContext> action)
        {
            throw new NotImplementedException();
        }

        public void ConfigureBuild(Action<HibernateDataContext> buildStrategy)
        {
            throw new NotImplementedException();
        }

        public HibernateDataContext Build()
        {
            throw new NotImplementedException();
        }
    }
}