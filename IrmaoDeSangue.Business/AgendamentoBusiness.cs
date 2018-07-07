using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business
{
    public class AgendamentoBusiness
    {
        protected AgendamentoData _agendamentoData { get; set; }

        public AgendamentoBusiness() : this(new AgendamentoData())
        { 

        }

        private AgendamentoBusiness(AgendamentoData agendamentoData)
        {
            _agendamentoData = new AgendamentoData();             
        }

        public IList<AgendamentoEntitie> RecuperaAgendamentosPendentes()
        {
            return _agendamentoData.RecuperaAgendamentosPendentes();
        }

        public void Atualiza(AgendamentoEntitie agendamentoEntitie)
        {
            _agendamentoData.Atualiza(agendamentoEntitie);
        }
    }
}
