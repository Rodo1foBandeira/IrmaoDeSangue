using FluentNHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public abstract class BaseData
    {
        public BaseData()
        { 

        }

        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        { 
            get
            {
                if (_sessionFactory == null)                
                {
                     var nhConfig = Fluently.Configure()
                    .Mappings(map => map.FluentMappings
                    .AddFromAssembly(Assembly.Load("IrmaoDeSangue.Data")))
                    .BuildConfiguration();

                    _sessionFactory = nhConfig.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
