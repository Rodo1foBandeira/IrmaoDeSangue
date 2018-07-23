using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using IrmaoDeSangue.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business
{
    public class DoadorBusiness
    {
        protected DoadorData _doadorData;

        public DoadorBusiness() : this(new IrmaoDeSangue.Data.DoadorData())
        { 

        }

        private DoadorBusiness(DoadorData doadorData)
        {
            _doadorData = doadorData;
        }

        public IList<DoadorEntitie> RecuperaPossiveisDoadores()
        {
            return _doadorData.RecuperaPossiveisDoadores();
        }

        public void AtualizaDadosDoadores(IList<DoadorEntitie> listaDoadores)
        {
            listaDoadores.ToList().ForEach(doador =>
            {
                _doadorData.Salvar(doador);
            });
        }

        public void ExecutaRegrasDoadorAptoInapito(AgendamentoEntitie agendamento)
        {
            var listaDoadoresIndefinido = _doadorData.RecuperaDoadoresIndefinidos();

            listaDoadoresIndefinido.ToList().ForEach(doador => {
                doador.AptoParaDoacaoTemporariamente = Validacao.ValidaDoadorBusiness.IsDoadorValidoTemporariamente(agendamento, doador);
                doador.AptoParaDoacaoPermanente = Validacao.ValidaDoadorBusiness.IsDoadorValidoPermanentemente(doador);
            });

            AtualizaDadosDoadores(listaDoadoresIndefinido.ToList());
        }
    }
}
