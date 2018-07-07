using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class AgendamentoEntitie : BaseEntities
    {
        public DateTime Data { get; set; }

        public HemonucleoEntitie Hemonucleo { get; set; }

        public Enumeradores.StatusProcessamentoEnum StatusProcessamento { get; set; }

        public int MaximoDoadores { get; set; }
    }
}
