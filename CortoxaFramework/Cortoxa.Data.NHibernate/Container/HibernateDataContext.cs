﻿using System;
using Cortoxa.Container.Component;
using Cortoxa.Data.Components;

namespace Cortoxa.Data.NHibernate.Container
{
    public class HibernateDataContext : DataSourceContext, ILifeTimeContext
    {
        public bool BuildSchema { get; set; }
        public bool UpdateSchema { get; set; }
    }
}