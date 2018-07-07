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

        public void ExecutaRegraDoadorInapitoPermanente()
        {
            var listaDoadoresIndefinido = _doadorData.RecuperaDoadoresIndefinidos();

            listaDoadoresIndefinido.ToList().ForEach(doador => {
                doador.AptoParaDoacao = IsDoadorApto(doador.DataNascimento, doador.Peso);
            });

            AtualizaDadosDoadores(listaDoadoresIndefinido.ToList());
        }

        private bool? IsDoadorApto(DateTime dataNascimento, float peso)
        {
            var retorno = true;

            if (DateTime.Now.Subtract(dataNascimento).Days < (365*18) || peso < 50)
                return false;

            return retorno;
        }
    }
}
