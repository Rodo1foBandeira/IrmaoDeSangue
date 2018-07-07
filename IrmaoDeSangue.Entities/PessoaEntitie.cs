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

        public DateTime DataNascimento { get; set; }

        public SexoPessoaEnum Sexo { get; set; }

        public string EstadoCivil { get; set; }

        public string Email { get; set; }

        public TipoPessoaEntitie TipoPessoa { get; set; }
    }
}
