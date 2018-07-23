using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class EnderecoEntitie : BaseEntities
    {
        public virtual string Logradouro { get; set; }

        public virtual string Numero { get; set; }

        public virtual string Complemento { get; set; }

        public virtual string Bairro { get; set; }

        public virtual string Cidade { get; set; }

        public virtual string Estado { get; set; }

        public virtual string Cep { get; set; }
    }
}
