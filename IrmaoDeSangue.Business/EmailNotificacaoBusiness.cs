using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            string corpoEmail = GetCorpoEmailNotificacao(notificacao);

            var mail = new MailMessage
            {
                From = new MailAddress("anderson.luiz.pinheiro@gmail.com", "Irmaos de Sangue"),
                Subject = "Agendamento para doação de sangue",
                IsBodyHtml = true,
                BodyEncoding = Encoding.UTF8,
                Body = corpoEmail
            };

            mail.To.Add(notificacao.Doador.Email);

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                Credentials = new System.Net.NetworkCredential 
                {
                    UserName = "",
                    Password = ""                    
                }
            };

            smtp.Send(mail);
        }

        private string GetCorpoEmailNotificacao(NotificacaoDoacaoEntitie notificacao)
        {
            StringBuilder sbCorpoEmail = new StringBuilder();

            var agendamento = notificacao.Agendamento;
            var doador = notificacao.Doador;
            var hemonucleo = agendamento.Hemonucleo;
            var enderecoHemoNucleo = hemonucleo.Enderecos.First(x => x.Ativo);

            sbCorpoEmail.AppendLine("Prezado " + notificacao.Doador.Descricao + ",<br>");
            sbCorpoEmail.AppendLine("<br>");
            sbCorpoEmail.AppendLine("Você foi selecionado para participação da " + agendamento.Descricao + ", por favor, confirme sua presença<br>");
            sbCorpoEmail.AppendLine("para doação na data " + notificacao.Agendamento.Data.ToString("dd/MM/yyyy") + " - Horário de atendimento " + notificacao.Agendamento.Hemonucleo.Atendimento + ", no local:<br>");
            sbCorpoEmail.AppendLine(notificacao.Agendamento.Hemonucleo.Descricao + "<br>");
            sbCorpoEmail.AppendLine(enderecoHemoNucleo.Logradouro + ", " + enderecoHemoNucleo.Numero + ", " + enderecoHemoNucleo.Bairro + "<br>");
            sbCorpoEmail.AppendLine(enderecoHemoNucleo.Cidade + "-" + enderecoHemoNucleo.Estado + "<br>");
            sbCorpoEmail.AppendLine("CEP " + enderecoHemoNucleo.Cep + "<br>");
            sbCorpoEmail.AppendLine("<br>");
            sbCorpoEmail.AppendLine("Campanha Irmão de Sangue, seja um doador de sangue, salve vidas.<br>");
            sbCorpoEmail.AppendLine("<br>");
            sbCorpoEmail.AppendLine("Por favor, confirmar presença - <a href='http://localhost:53911/Questionario/Responder?idPessoa=" + doador.Codigo + "&chave=" + notificacao.ChaveAutenticacao + "'>Clicando aqui</a><br>");
            sbCorpoEmail.AppendLine("<br>");
            sbCorpoEmail.AppendLine("<br>");
            sbCorpoEmail.AppendLine("Obrigado");

            return sbCorpoEmail.ToString();
        }
    }
}
