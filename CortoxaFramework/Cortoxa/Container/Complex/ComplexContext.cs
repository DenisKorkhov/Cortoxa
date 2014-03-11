using System;
using System.Collections.Generic;

namespace Cortoxa.Container.Complex
{
    public class ComplexContext
    {
        private readonly IList<Action> confiurationActions = new List<Action>();

        public IList<Action> ConfiurationActions
        {
            get { return confiurationActions; }
        } 
    }
}