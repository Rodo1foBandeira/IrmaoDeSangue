using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business.Validacao
{
    public class ValidaDoadorBusiness
    {
        public static bool IsDoadorValidoTemporariamente(AgendamentoEntitie agendamento, DoadorEntitie doador)
        {
            var retorno = true;

            if (!IsDoadorPesoMinimoValido(doador) || !IsDoadorIdadeMinimaValido(doador) || !IsDoacaoValidaNoPeriodo(agendamento, doador))
            {
                retorno = false;
            }
            
            return retorno;
        }

        public static bool IsDoadorValidoPermanentemente(DoadorEntitie doador)
        {
            var retorno = true;

            if (!IsDoadorIdadeMaximaValido(doador))
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool IsDoacaoValidaNoPeriodo(AgendamentoEntitie agendamento, DoadorEntitie doador)
        {
            bool retorno = true;

            DateTime periodoFinal = agendamento.Data;
            DateTime periodoInicial = agendamento.Data.AddYears(-1);

            doador.QuantidadeDoacoes = doador.Doacoes == null ? 0 : doador.Doacoes.Count;

            if (doador.QuantidadeDoacoes >= 3)
            {
                doador.QuantidadeDoacoes = doador.Doacoes.ToList().Count(x =>
                        x.DataConfirmacaoDoacao >= periodoInicial &&
                        x.DataConfirmacaoDoacao <= periodoFinal);

                if ((doador.Sexo == Entities.Enumeradores.SexoPessoaEnum.F && doador.QuantidadeDoacoes > 3)
                    || (doador.Sexo == Entities.Enumeradores.SexoPessoaEnum.M && doador.QuantidadeDoacoes > 4))
                {
                    retorno = false;
                }
            }

            return retorno;
        }

        public static bool IsDoadorPesoMinimoValido(DoadorEntitie doador)
        {
            var retorno = true;

            if (doador.Peso < 50) // Peso mínimo 50 Kg
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool IsDoadorIdadeMinimaValido(DoadorEntitie doador)
        {
            var retorno = true;

            if (!doador.DataNascimento.HasValue || 
                doador.DataNascimento.Value.AddYears(18).CompareTo(DateTime.Now) >= 0) //Minimo de 18 anos de idade
            {
                retorno = false;
            }

            return retorno;
        }

        public static bool IsDoadorIdadeMaximaValido(DoadorEntitie doador)
        {
            var retorno = true;

            if (!doador.DataNascimento.HasValue ||
                doador.DataNascimento.Value.AddYears(65).CompareTo(DateTime.Now) < 1) //Máximo de 65 anos de idade
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
