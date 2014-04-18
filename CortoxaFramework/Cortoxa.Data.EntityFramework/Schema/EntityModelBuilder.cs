using System;
using System.Data.Entity;
using Cortoxa.Configuration;
using Cortoxa.Data.Model;
using Cortoxa.Data.Schema;
using Cortoxa.Data.Schema.Models;

namespace Cortoxa.Data.EntityFramework.Schema
{
    public class EntityModelBuilder : IModelBuilder//, IConfigurator<ModelContext>, IConfiguratorBuilder<ModelContext>
    {
        private readonly DbModelBuilder dbModelBuilder;

        public EntityModelBuilder(DbModelBuilder dbModelBuilder)
        {
            this.dbModelBuilder = dbModelBuilder;
        }

        public ITableModel<T> ForEntity<T>() where T : IEntity
        {
            throw new NotImplementedException();
        }

        public ITableModel<T> ForEntity<T>(string tableName) where T : IEntity
        {
            throw new NotImplementedException();
        }

        public ITableModel<T> ForEntity<T>(Type type, string tableName) where T : IEntity
        {
            throw new NotImplementedException();
        }

//        public void ConfigureBuild(Action<ModelContext> buildStrategy)
//        {
//            throw new NotImplementedException();
//        }
//
//        ModelContext IConfiguratorBuilder<ModelContext>.Build()
//        {
//            throw new NotImplementedException();
//        }

        public void Build()
        {

//            dbModelBuilder.Entity<string>().
        }

//        public void Setup(Action<Action<ModelContext>> contextAction)
//        {
//            throw new NotImplementedException();
//        }
//
//        public void Configure(Action<ModelContext> action)
//        {
//            throw new NotImplementedException();
//        }
    }
}