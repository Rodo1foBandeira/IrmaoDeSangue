using IrmaoDeSangue.Entities;
using IrmaoDeSangue.Entities.Enumeradores;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class AgendamentoData : BaseData
    {
        public AgendamentoData()
        {

        }

        public IList<AgendamentoEntitie> RecuperaAgendamentosPendentes()
        {
            var criteria = GetSession().CreateCriteria<AgendamentoEntitie>("AgendamentoEntitie");
            criteria.Add(Restrictions.Eq("AgendamentoEntitie.StatusProcessamento", (int)StatusProcessamentoEnum.Pendente));

            return criteria.List<AgendamentoEntitie>();
        }
    }
}
