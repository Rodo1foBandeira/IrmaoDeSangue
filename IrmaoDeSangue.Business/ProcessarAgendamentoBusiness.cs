using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business
{
    public class ProcessarAgendamentoBusiness
    {
        protected AgendamentoData _agendamentoData;
        protected DoadorBusiness _doadoresBusiness;

        public ProcessarAgendamentoBusiness()
        {
            _agendamentoData = new AgendamentoData();
            _doadoresBusiness = new DoadorBusiness();
        }

        public void Processar()
        {
            var listaAgendamentosPendentes = _agendamentoData.RecuperaAgendamentosPendentes();

            listaAgendamentosPendentes.ToList().ForEach(agendamento => 
                ProcessarAgendamento(agendamento)
            );
        }

        private void ProcessarAgendamento(AgendamentoEntitie agendamento)
        {
            agendamento.StatusProcessamento = Entities.Enumeradores.StatusProcessamentoEnum.Processando;
            
            _agendamentoData.Atualiza(agendamento);

            _doadoresBusiness.ExecutaRegraDoadorInapitoPermanente();

            var listaPossiveisDoadores = _doadoresBusiness.RecuperaPossiveisDoadores();



        }
    }
}
