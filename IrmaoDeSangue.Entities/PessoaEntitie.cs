using IrmaoDeSangue.Entities.Enumeradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class PessoaEntitie : BaseEntities
    {
        public PessoaEntitie()
        { 

        }

        public virtual DateTime DataNascimento { get; set; }

        public virtual SexoPessoaEnum Sexo { get; set; }

        public virtual string EstadoCivil { get; set; }

        public virtual string Email { get; set; }

        public virtual TipoPessoaEntitie TipoPessoa { get; set; }
    }
}
