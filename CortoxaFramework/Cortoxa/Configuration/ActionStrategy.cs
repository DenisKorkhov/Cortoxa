using System;
using System.Collections.Generic;
using Cortoxa.Tool;

namespace Cortoxa.Configuration
{
    public class ActionStrategy : IConfigurationStrategy<IList<Action>>
    {
        public IList<Action> CreateContext()
        {
            return new List<Action>();
        }

        public void Execute(IList<Action> context)
        {
            foreach (var action in context)
            {
                action();
            }
        }

        public void Execute(Context<IList<Action>> context)
        {
            throw new NotImplementedException();
        }
    }
}