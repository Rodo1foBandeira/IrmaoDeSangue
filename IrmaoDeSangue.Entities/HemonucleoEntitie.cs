using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class HemonucleoEntitie : BaseEntities
    {
        public string Atendimento { get; set; }

        public string Responsavel { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }
    }
}
