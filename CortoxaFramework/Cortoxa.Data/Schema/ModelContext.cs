using System;
using System.Linq.Expressions;

namespace Cortoxa.Data.Schema
{
    public class ModelContext<T>
    {
        public Type EntityType { get; set; }

        public Expression<Func<T, object>> Property { get; set; }

        public bool IsRequired { get; set; }

        public int MaxLength { get; set; }

        public string TableName { get; set; }
    }


    public class ModelManyContext
    {

    }
}