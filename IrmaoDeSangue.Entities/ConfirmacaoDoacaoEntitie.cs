using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class ConfirmacaoDoacaoEntitie : BaseEntities
    {
        public virtual NotificacaoDoacaoEntitie Notificacao { get; set; }

        public virtual DateTime DataEnvioSolicitacaoConfirmacao { get; set; }

        public virtual DateTime DataConfirmacaoDoacao { get; set; }

        public virtual bool? DoacaoRealizada { get; set; }
    }
}
