using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IrmaoDeSangue.Business;
using IrmaoDeSangue.Entities;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class QuestionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Responder(int idPessoa, string chave)
        {
            /*var notificacao = RecuperarNotificacao(idPessoa, chave);

            if (notificacao == null)
            {
                return Redirect("~/Home");
            }

            var perguntaBuss = new PerguntaBusiness();
            var perg = perguntaBuss.RecuperaPerguntas();

            var perguntas = new List<PerguntaModel>();
            perg.ToList<PerguntaEntitie>().ForEach(x =>
            {
                perguntas.Add(new PerguntaModel { Codigo = x.Codigo, Descricao = x.Descricao, Tipo = (int)x.TipoPergunta });
            });

            var pessoa = new PessoaModel { Codigo = idPessoa, NomeCompleto = notificacao.Doador.Descricao };

            var questionario = new QuestionarioModel { Pessoa = pessoa, Perguntas = perguntas };
            */

            var questionario = new QuestionarioModel
            {
                Pessoa = new PessoaModel { Codigo = 1, NomeCompleto = "Fulano de Tal"},
                Perguntas = new List<PerguntaModel>
                {
                    new PerguntaModel { Codigo = 1, Descricao = "Você fez tatuagem a menos de 1 ano?"},
                    new PerguntaModel { Codigo = 1, Descricao = "Você fez cirurgia a menos de 1 ano?"},
                }
            };

            return View(questionario);
        }

        public IActionResult ValidarRespostas(QuestionarioModel questionario)
        {
            questionario.Pessoa.NomeCompleto = "Fulano de tal";
            questionario.Pessoa.Aprovado = true;
            return View("~/Views/Questionario/Resultado.cshtml", questionario.Pessoa);
        }

        private NotificacaoDoacaoEntitie RecuperarNotificacao(int codigoPessoa, string chaveAutenticacao)
        {
            var notificacaoBusiness = new NotificacaoBusiness();

            var notificacaoDoador = notificacaoBusiness.RecuperaPorCodigoEChaveAutenticacao(codigoPessoa, chaveAutenticacao);

            return notificacaoDoador;
        }
    }
}