using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business
{
    public class EmailNotificacaoBusiness
    {
        public EmailNotificacaoBusiness()
        {

        }

        public void EnviarEmail(NotificacaoDoacaoEntitie notificacao)
        {

        }

        private string GetCorpoEmailNotificacao(NotificacaoDoacaoEntitie notificacao)
        {
            StringBuilder sbCorpoEmail = new StringBuilder();

            sbCorpoEmail.AppendLine("Prezado " + notificacao.Doador.Descricao + ",");
            sbCorpoEmail.AppendLine("");
            sbCorpoEmail.AppendLine("Você foi selecionado para participação da CAMPANHA IRMÃO DE SANGUE, por favor confirmar presença");
            sbCorpoEmail.AppendLine("No dia dd/mm/aaaa - das 07:00-11:30 e 14:00-16:00, no local:");
            sbCorpoEmail.AppendLine("Hemonúcleo Regional de Araraquara");
            sbCorpoEmail.AppendLine("Rua Expedicionários do Brasil, 1621, Centro");
            sbCorpoEmail.AppendLine("Araraquara-SP");
            sbCorpoEmail.AppendLine("CEP 14801-360");
            sbCorpoEmail.AppendLine("");
            sbCorpoEmail.AppendLine("Campanha Irmão de Sangue, seja um doador de sangue, salve vidas.");
            sbCorpoEmail.AppendLine("");
            sbCorpoEmail.AppendLine("Por favor, confirmar presença - respondendo a esta mensagem.");
            sbCorpoEmail.AppendLine("");
            sbCorpoEmail.AppendLine("");
            sbCorpoEmail.AppendLine("Obrigado");

            return sbCorpoEmail.ToString();
        }
    }
}
