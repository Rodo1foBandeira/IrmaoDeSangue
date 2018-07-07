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

        public virtual string TipoSanguinio { get; set; }

        public virtual bool? AptoParaDoacao { get; set; }

        public virtual float Peso { get; set; }

        public virtual DateTime? UltimaDoacao { get; set; }

        public virtual IList<ConfirmacaoDoacaoEntitie> Doacoes { get; set; }

        public virtual int QuantidadeDoacoes { get; set; }
    }
}
