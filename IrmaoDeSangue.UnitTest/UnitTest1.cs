using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IrmaoDeSangue.Business;
using IrmaoDeSangue.Entities;
using IrmaoDeSangue.Business.Validacao;

namespace IrmaoDeSangue.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestaProcessamentoSelecaoDoadores()
        {
            var _processarAgendamento = new ProcessarAgendamentoBusiness();

            string result = _processarAgendamento.Processar();

            Assert.IsTrue(result.Contains("agendamento(s) processsado(s)"), result);
        }

        [TestMethod]
        public void TestePositivoValidacaoPorIdadeMinima()
        {
            var doador = new DoadorEntitie 
            {
                DataNascimento = DateTime.Now.AddYears(-18)
            };

            var result = ValidaDoadorBusiness.IsDoadorIdadeMinimaValido(doador);

            Assert.AreEqual(result, true, "Sucesso");
        }

        [TestMethod]
        public void TesteNegativoValidacaoPorIdadeMinima()
        {
            var doador = new DoadorEntitie
            {
                DataNascimento = DateTime.Now.AddYears(-17)
            };

            var result = ValidaDoadorBusiness.IsDoadorIdadeMinimaValido(doador);

            Assert.AreEqual(!result, true, "Sucesso");
        }

        [TestMethod]
        public void TestaPositivoValidacaoPorIdadeMaxima()
        {
            var doador = new DoadorEntitie
            {
                DataNascimento = DateTime.Now.AddYears(-64)
            };

            var result = ValidaDoadorBusiness.IsDoadorIdadeMaximaValido(doador);

            Assert.AreEqual(result, true, "Sucesso");
        }

        [TestMethod]
        public void TestaNegativoValidacaoPorIdadeMaxima()
        {
            var doador = new DoadorEntitie { DataNascimento = DateTime.Now.AddYears(-66) };

            var result = ValidaDoadorBusiness.IsDoadorIdadeMaximaValido(doador);

            Assert.AreEqual(!result, true, "Sucesso");
        }
    
        [TestMethod]
        public void TestaPositivoValidacaoSexoMasculinoPorPeriodo()
        {
            var agendamento = new AgendamentoEntitie { Data = DateTime.Now };
            var doadorMaculino = new DoadorEntitie { Sexo = Entities.Enumeradores.SexoPessoaEnum.M };
            bool result = true;

            result = ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorMaculino);

            doadorMaculino.Doacoes = new System.Collections.Generic.List<ConfirmacaoDoacaoEntitie>();
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-8) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-6) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-4) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-2) });

            result = result && ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorMaculino);

            Assert.AreEqual(result, true, "Sucesso");
        }

        [TestMethod]
        public void TestaNegativoValidacaoSexoMasculinoPorPeriodo()
        {
            var agendamento = new AgendamentoEntitie { Data = DateTime.Now };
            var doadorMaculino = new DoadorEntitie { Sexo = Entities.Enumeradores.SexoPessoaEnum.M };            
            bool result = true;

            result = ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorMaculino);

            doadorMaculino.Doacoes = new System.Collections.Generic.List<ConfirmacaoDoacaoEntitie>();
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-10) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-8) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-6) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-4) });
            doadorMaculino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-2) });

            result = result && ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorMaculino);

            Assert.AreEqual(!result, true, "Sucesso");
        }

        [TestMethod]
        public void TestaPositivoValidacaoSexoFemininoPorPeriodo()
        {
            var agendamento = new AgendamentoEntitie { Data = DateTime.Now };
            var doadorFeminino = new DoadorEntitie { Sexo = Entities.Enumeradores.SexoPessoaEnum.F };
            bool result = true;

            result = ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorFeminino);

            doadorFeminino.Doacoes = new System.Collections.Generic.List<ConfirmacaoDoacaoEntitie>();
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-8) });
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-6) });
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-4) });            

            result = result && ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorFeminino);

            Assert.AreEqual(result, true, "Sucesso");
        }

        [TestMethod]
        public void TestaNegativoValidacaoSexoFemininoPorPeriodo()
        {
            var agendamento = new AgendamentoEntitie { Data = DateTime.Now };
            var doadorFeminino = new DoadorEntitie { Sexo = Entities.Enumeradores.SexoPessoaEnum.F };                        
            bool result = true;

            result = ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorFeminino);

            doadorFeminino.Doacoes = new System.Collections.Generic.List<ConfirmacaoDoacaoEntitie>();
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-10) });
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-8) });
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-6) });
            doadorFeminino.Doacoes.Add(new ConfirmacaoDoacaoEntitie { DataConfirmacaoDoacao = DateTime.Now.AddMonths(-4) });

            result = result && ValidaDoadorBusiness.IsDoacaoValidaNoPeriodo(agendamento, doadorFeminino);

            Assert.AreEqual(!result, true, "Sucesso");
        }

    }
}
