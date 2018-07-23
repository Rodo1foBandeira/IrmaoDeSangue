using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities.Enumeradores
{
    public enum StatusProcessamentoEnum
    {        
        AguardandoProcessamento = 1,
        Processando = 2,
        ProcessadoComSucesso = 3,
        ProcessadoComErro = 4
    }
}
