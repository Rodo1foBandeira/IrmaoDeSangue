using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class DoadorEntitie : PessoaEntitie
    {
        public DoadorEntitie()
        { 

        }

        public string TipoSanguinio { get; set; }

        public bool? AptoParaDoacao { get; set; }

        public float Peso { get; set; }

        public DateTime? UltimaDoacao { get; set; }

        public IList<ConfirmacaoDoacaoEntitie> Doacoes { get; set; }

        public int QuantidadeDoacoes { get; set; }
    }
}
