using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.IData
{
    public interface IDoadorData
    {
        IList<DoadorEntitie> RecuperaPossiveisDoadores();

        void Salvar(DoadorEntitie doador);
    }
}
