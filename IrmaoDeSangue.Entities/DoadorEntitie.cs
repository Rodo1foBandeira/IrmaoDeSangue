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

        public virtual bool? AptoParaDoacaoPermanente { get; set; }

        public virtual bool? AptoParaDoacaoTemporariamente { get; set; }

        public virtual float Peso { get; set; }

        public virtual DateTime? UltimaDoacao { get; set; }

        public virtual ICollection<ConfirmacaoDoacaoEntitie> Doacoes { get; set; }

        public virtual int QuantidadeDoacoes { get; set; }

        public virtual int ChaveSorteio { get; set; }
    }
}
