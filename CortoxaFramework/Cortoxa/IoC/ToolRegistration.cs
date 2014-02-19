#region Copyright © 2014 Denis Korkhov, Oxagile (http://www.oxagile.com/)
// /*
//  * All rights reserved. This program and the accompanying materials
//  * are made available under the terms of the GNU Lesser General Public License
//  * (LGPL) version 2.1 which accompanies this distribution, and is available at
//  * http://www.gnu.org/licenses/lgpl-2.1.html
//  *
//  *  Filename:	ToolRegistration.cs
//  *  Date:		05/02/2014
//  *  Author:   	Denis Korkhov
//  *
//  */
#endregion
using System;
using System.Linq;
using System.Reflection;
using Cortoxa.IoC.Attributes;
using Cortoxa.IoC.Registration;

namespace Cortoxa.IoC
{
    public class ToolRegistration : IComponentRegistration, ITypeRegistration, IToolRegistration
    {
        #region Fields

        private TypeContext _context = new TypeContext(); 

        #endregion

        #region Private members 

        private ToolRegistration()
        {
        }

        #endregion

        protected virtual void CreateTypeContext()
        {
            _context = new TypeContext();
        }

        public static IToolRegistration Types
        {
            get
            {
                var registration = new ToolRegistration();
                registration.CreateTypeContext();
                return registration;
            }
        }

        #region Implementation of IToolRegistration

        public IComponentRegistration For<T>()
        {
            return For(typeof (T));
        }

        public IComponentRegistration For(Type type)
        {
            _context.For = type;
            return this;
        }

        public ITypeRegistration From(params Assembly[] assemblies)
        {
            _context.Assemblies.Clear();
            foreach (var assembly in assemblies)
            {
                _context.Assemblies.Add(assembly);
            }
            return this;
        }

        public ITypeRegistration FromNamespace<T>()
        {
            _context.Assemblies.Clear();
            _context.Assemblies.Add(typeof(T).Assembly);
            _context.Namespace = typeof (T).Namespace;
            return this;
        }

        public IComponentRegistration To<T>()
        {
            return To(typeof(T));
        }

        public IComponentRegistration To(Type type)
        {
            _context.To = type;
            return this;
        }

        public IComponentRegistration Name(string name)
        {
            _context.Name = name;
            return this;
        }

        public IComponentRegistration ToSelf()
        {
            if (_context.For == null)
            {
                throw new Exception("Type From is not initialized");
            }
            _context.To = _context.For;
            return this;
        }

        public IComponentRegistration With(object attributies)
        {
            _context.Attributies = attributies;
            return this;
        }

        public IComponentRegistration DependsOn<T>(string serviceName)
        {
            return DependsOn(typeof (T), serviceName);
        }

        public IComponentRegistration DependsOn(Type service, string serviceName)
        {
            _context.Dependencies.Add(service, serviceName);
            return this;
        }

        public IToolRegistration LifeTime(ToolkitLifeTime lifeTime)
        {
            _context.Lifetime = lifeTime;
            return this;
        }

        public TypeContext Context
        {
            get { return _context; }
        }

        #endregion
    }
}