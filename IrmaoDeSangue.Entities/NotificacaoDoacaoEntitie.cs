using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Entities
{
    public class NotificacaoDoacaoEntitie : BaseEntities
    {
        public AgendamentoEntitie Agendamento { get; set; }

        public DoadorEntitie Doador { get; set; }

        public DateTime DataNotificacao { get; set; }

        public string ChaveAutenticacao { get; set; }

        public bool Confirmado { get; set; }

        public DateTime? DataConfirmacao { get; set; }
    }
}
