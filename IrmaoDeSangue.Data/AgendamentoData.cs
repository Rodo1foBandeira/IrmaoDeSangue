using IrmaoDeSangue.Entities;
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
            var lista = new List<AgendamentoEntitie>();

            return lista;
        }

        public void Atualiza(AgendamentoEntitie agendamentoEntitie)
        { 

        }
    }
}
