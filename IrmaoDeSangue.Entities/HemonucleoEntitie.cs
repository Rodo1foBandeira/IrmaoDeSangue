using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class HemonucleoEntitie : BaseEntities
    {
        public virtual string Atendimento { get; set; }

        public virtual PessoaEntitie Responsavel { get; set; }

        public virtual string Telefone { get; set; }

        public virtual string Email { get; set; }

        public virtual string Site { get; set; }

        public virtual ICollection<EnderecoEntitie> Enderecos { get; set; }
    }
}
