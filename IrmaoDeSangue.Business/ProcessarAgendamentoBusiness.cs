using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using IrmaoDeSangue.IBusiness;
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
        protected ConfirmacaoDoacaoData _confimacaoDoacoesData;
        protected NotificacaoBusiness _notificiacaoBusiness;
        
        public ProcessarAgendamentoBusiness()
        {
            _agendamentoData = new AgendamentoData();
            _doadoresBusiness = new DoadorBusiness();
            _confimacaoDoacoesData = new ConfirmacaoDoacaoData();
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
            agendamento.StatusProcessamento = (int)Entities.Enumeradores.StatusProcessamentoEnum.Processando;
            
            _agendamentoData.Salvar(agendamento);

            _doadoresBusiness.ExecutaRegraDoadorInapitoPermanente();

            var listaPossiveisDoadores = _doadoresBusiness.RecuperaPossiveisDoadores();
            var listaDoadores = new List<DoadorEntitie>();

            DateTime periodoFinal = agendamento.Data;
            DateTime periodoInicial = agendamento.Data.AddYears(-1);

            listaPossiveisDoadores.ToList().ForEach(doador => 
            {
                if (IsDoacaoValidaNoPeriodo(periodoInicial, periodoFinal, doador))
                {
                    listaDoadores.Add(doador);
                }
            });

            listaDoadores = listaDoadores.OrderBy(x => x.QuantidadeDoacoes).ToList();
            listaDoadores = listaDoadores.Take(agendamento.MaximoDoadores).ToList();

            listaDoadores.ForEach(doadorSelecionado => 
            {
                var notificacao = new NotificacaoDoacaoEntitie
                {
                    Confirmado = false,
                    DataNotificacao = DateTime.Now,                    
                    Doador = doadorSelecionado,
                    Agendamento = agendamento
                };

                _notificiacaoBusiness.Notificar(notificacao);                
            });

            agendamento.StatusProcessamento = (int)Entities.Enumeradores.StatusProcessamentoEnum.Processado;
            
            _agendamentoData.Salvar(agendamento);
        }

        private bool IsDoacaoValidaNoPeriodo(DateTime periodoInicial, DateTime periodoFinal, DoadorEntitie doador)
        {
            bool retorno = true;

            doador.QuantidadeDoacoes = doador.Doacoes.Count;

            if (doador.QuantidadeDoacoes >= 3)
            {
                doador.QuantidadeDoacoes = doador.Doacoes.ToList().Count(x =>
                        x.DataConfirmacaoDoacao >= periodoInicial &&
                        x.DataConfirmacaoDoacao <= periodoFinal);

                if ((doador.Sexo == Entities.Enumeradores.SexoPessoaEnum.Feminino && doador.QuantidadeDoacoes > 3)
                    || (doador.Sexo == Entities.Enumeradores.SexoPessoaEnum.Masculino && doador.QuantidadeDoacoes > 4))
                {
                    retorno = false;
                }
            }

            return retorno;
        }
    }
}
