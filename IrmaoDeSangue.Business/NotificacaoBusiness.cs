using IrmaoDeSangue.Business;
using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.IBusiness
{
    public class NotificacaoBusiness
    {
        protected EmailNotificacaoBusiness _emailNotificacaoBusiness;

        public NotificacaoBusiness()
        {
            _emailNotificacaoBusiness = new EmailNotificacaoBusiness();
        }

        public void Notificar(NotificacaoDoacaoEntitie notificacao)
        {
            Salvar(notificacao);

            _emailNotificacaoBusiness.EnviarEmail(notificacao);
        }

        private void Salvar(NotificacaoDoacaoEntitie notificacao)
        {

        }
    }
}
