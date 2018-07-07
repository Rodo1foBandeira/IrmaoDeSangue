using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class NotificacaoDoacaoEntitie : BaseEntities
    {
        public virtual AgendamentoEntitie Agendamento { get; set; }

        public virtual DoadorEntitie Doador { get; set; }

        public virtual DateTime DataNotificacao { get; set; }

        public virtual string ChaveAutenticacao { get; set; }

        public virtual bool Confirmado { get; set; }

        public virtual DateTime? DataConfirmacao { get; set; }
    }
}
