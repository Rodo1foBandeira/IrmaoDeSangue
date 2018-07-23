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
            var criteria = GetSession().QueryOver<AgendamentoEntitie>()
                .Where(x => x.StatusProcessamento == (int)StatusProcessamentoEnum.AguardandoProcessamento);            

            return criteria.List<AgendamentoEntitie>();
        }

        public AgendamentoEntitie RecuperaPorCodigo(int codigoAgendamento)
        {
            var criteria = GetSession().QueryOver<AgendamentoEntitie>()
                .Where(x => x.Codigo == codigoAgendamento);            

            return criteria.SingleOrDefault<AgendamentoEntitie>();
        }
    }
}
