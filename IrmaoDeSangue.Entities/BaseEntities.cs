using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class BaseEntities
    {
        public virtual int Codigo { get; set; }

        public virtual string Descricao { get; set; }

        public virtual bool Ativo { get; set; }
    }
}
