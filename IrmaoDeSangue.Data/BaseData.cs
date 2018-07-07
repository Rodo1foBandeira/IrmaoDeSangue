using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public abstract class BaseData
    {
        protected readonly ISession Session;

        protected BaseData(ISession session);

        public virtual int Count<T>(Expression<Func<T, bool>> where) where T : class;
        
        public virtual void Delete<T>(T entity) where T : class;
        
        public virtual void Evict(object entity);
        
        public virtual void Insert<T>(T entity) where T : class;
        
        public virtual IList<T> List<T>() where T : class;
        
        public virtual IList<T> Query<T>(Expression<Func<T, bool>> where) where T : class;
        
        public virtual void Save<T>(T entity) where T : class;
        
        public virtual void Update<T>(T entity) where T : class;
    }
}
