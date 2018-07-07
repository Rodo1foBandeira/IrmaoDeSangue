using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.IBusiness
{
    public interface IDoadorBusiness
    {
        IList<DoadorEntitie> RecuperaPossiveisDoadores();

        void AtualizaDadosDoadores(IList<DoadorEntitie> listaDoadores);

        void ExecutaRegraDoadorInapitoPermanente(IList<DoadorEntitie> listaDoadores);
    }
}
