using IrmaoDeSangue.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class DoadorData : BaseData
    {
        public DoadorData()
        { 

        }

        public IList<DoadorEntitie> RecuperaDoadoresIndefinidos()
        {
            var lista = new List<DoadorEntitie>();

            return lista;
        }

        public IList<DoadorEntitie> RecuperaPossiveisDoadores()
        {
            var lista = new List<DoadorEntitie>();

            return lista;
        }

        public void Salvar(DoadorEntitie doador)
        {
            
        }
    }
}
