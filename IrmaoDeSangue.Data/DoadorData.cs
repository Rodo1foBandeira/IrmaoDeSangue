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
        public DoadorData(ISession session)
            : base(session)
        {

        }

        public IList<Doador> RecuperaPossiveisDoadores()
        {
            var lista = new List<Doador>();

            return lista;
        }

        public void Salvar(Doador doador)
        {
            if (doador.Codigo > 0)
            {
                Update(doador);
            }
            else
            {
                Save(doador);
            }
        }
    }
}
