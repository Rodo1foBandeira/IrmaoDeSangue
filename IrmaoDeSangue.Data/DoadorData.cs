using IrmaoDeSangue.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class DoadorData : BaseData
    {
        public DoadorData()
        { 

        }

        public IList<DoadorEntitie> RecuperaDoadoresIndefinidos()
        {
            var criteria = GetSession().CreateCriteria<DoadorEntitie>("DoadorEntitie");
            criteria.Add(Restrictions.Eq("DoadorEntitie.AptoParaDoacao", null));

            return criteria.List<DoadorEntitie>();
        }

        public IList<DoadorEntitie> RecuperaPossiveisDoadores()
        {
            var criteria = GetSession().CreateCriteria<DoadorEntitie>("DoadorEntitie");
            criteria.CreateCriteria("DoadorEntitie.Doacoes", "Doacoes", JoinType.LeftOuterJoin);
            criteria.Add(Restrictions.Eq("DoadorEntitie.AptoParaDoacao", 1));

            return criteria.List<DoadorEntitie>();
        }

        public void Salvar(DoadorEntitie doador)
        {
            
        }
    }
}
