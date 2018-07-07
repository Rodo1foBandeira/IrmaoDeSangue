using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class AgendamentoEntitie : BaseEntities
    {
        public AgendamentoEntitie()
        { 

        }

        public virtual DateTime Data { get; set; }

        public virtual HemonucleoEntitie Hemonucleo { get; set; }

        public virtual int StatusProcessamento { get; set; }

        public virtual int MaximoDoadores { get; set; }
    }
}
