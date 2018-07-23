using IrmaoDeSangue.Business.Sorteio;
using IrmaoDeSangue.Business.Validacao;
using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using IrmaoDeSangue.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using IrmaoDeSangue.Entities.Enumeradores;

namespace IrmaoDeSangue.Business
{
    public class ProcessarAgendamentoBusiness
    {
        protected AgendamentoBusiness _agendamentoBusiness;
        protected DoadorBusiness _doadoresBusiness;
        protected ConfirmacaoDoacaoData _confimacaoDoacoesData;
        protected NotificacaoBusiness _notificiacaoBusiness;

        public ProcessarAgendamentoBusiness()
        {
            _agendamentoBusiness = new AgendamentoBusiness();
            _doadoresBusiness = new DoadorBusiness();
            _confimacaoDoacoesData = new ConfirmacaoDoacaoData();
            _notificiacaoBusiness = new NotificacaoBusiness();
        }

        public string Processar()
        {
            var qtdNotificacaoes = 0;

            var listaAgendamentosPendentes = _agendamentoBusiness.RecuperaAgendamentosPendentes();

            listaAgendamentosPendentes.ToList().ForEach(agendamento => {
                
                ProcessarAptidaoDoadores(agendamento);

                ProcessarAgendamento(agendamento);
                
                qtdNotificacaoes++;

            });

            return qtdNotificacaoes + " agendamento(s) processsado(s)";
        }

        private void ProcessarAgendamento(AgendamentoEntitie agendamento)
        {
            AtualizaStatusProcessamentoAgendamento(agendamento, StatusProcessamentoEnum.Processando);

            agendamento = _agendamentoBusiness.RecuperaPorCodigo(agendamento.Codigo);

            bool sucesso = false;
            
            using (var transation = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    var listaPossiveisDoadores = _doadoresBusiness.RecuperaPossiveisDoadores();

                    var listaDoadoresSorteados = SorteioDoadorBusiness.SortearDoadoresValidos(listaPossiveisDoadores, agendamento.MaximoDoadores);

                    listaDoadoresSorteados.ForEach(doadorSelecionado =>
                    {
                        var notificacao = GetInstaciaObjetoNotificacao(agendamento, doadorSelecionado);

                        _notificiacaoBusiness.Notificar(notificacao);
                    });                    

                    transation.Complete();

                    sucesso = true;
                }
                catch (Exception)
                {
                    //TODO: Implementar log de erro
                    sucesso = false;
                }
            }

            if (sucesso)
            {
                AtualizaStatusProcessamentoAgendamento(agendamento, StatusProcessamentoEnum.ProcessadoComSucesso);
            }
            else
            {
                AtualizaStatusProcessamentoAgendamento(agendamento, StatusProcessamentoEnum.ProcessadoComErro);
            }
        }

        private void AtualizaStatusProcessamentoAgendamento(AgendamentoEntitie agendamento, StatusProcessamentoEnum status)
        {
            using (var transation = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                agendamento.StatusProcessamento = (int)StatusProcessamentoEnum.Processando;

                _agendamentoBusiness.Salvar(agendamento);
            }
        }

        private void ProcessarAptidaoDoadores(AgendamentoEntitie agendamento)
        {
            using (var transation = new TransactionScope(TransactionScopeOption.Required))
            {
                _doadoresBusiness.ExecutaRegrasDoadorAptoInapito(agendamento);

                transation.Complete();
            }
        }

        private NotificacaoDoacaoEntitie GetInstaciaObjetoNotificacao(AgendamentoEntitie agendamento, DoadorEntitie doadorSelecionado)
        {
            return new NotificacaoDoacaoEntitie
            {
                Confirmado = false,
                DataNotificacao = DateTime.Now,
                Doador = doadorSelecionado,
                Agendamento = agendamento,
                ChaveAutenticacao = Guid.NewGuid().ToString()
            };
        }
    }
}
