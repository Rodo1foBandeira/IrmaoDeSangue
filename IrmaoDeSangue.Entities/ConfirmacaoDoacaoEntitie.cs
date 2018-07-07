using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class ConfirmacaoDoacaoEntitie : BaseEntities
    {
        public NotificacaoDoacaoEntitie Notificacao { get; set; }

        public DateTime DataEnvioSolicitacaoConfirmacao { get; set; }

        public DateTime DataConfirmacaoDoacao { get; set; }

        public bool? DoacaoRealizada { get; set; }
    }
}
