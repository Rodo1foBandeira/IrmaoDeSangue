using FluentNHibernate.Cfg;
using IrmaoDeSangue.Entities;
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

        public void Salvar<T>(T objeto) where T : BaseEntities
        {
            if (objeto.Codigo > 0)
            {
                var evict = GetSession().Load<T>(objeto.Codigo);
                if (evict != null)
                    GetSession().Evict(evict);
            }

            GetSession().SaveOrUpdate(objeto);
        }

    }
}
