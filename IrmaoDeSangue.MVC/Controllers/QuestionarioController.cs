using IrmaoDeSangue.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IrmaoDeSangue.MVC.Controllers
{
    public class QuestionarioController : Controller
    {
        //
        // GET: /Questionario/

        public ActionResult Index()
        {
            return View();             
        }

        public ActionResult Responder(int idPessoa, string chave)
        {
            var pessoa = new PessoaModel { Codigo = idPessoa, NomeCompleto = "Todo: pegar no banco" };

            var perguntas = new List<PerguntaModel>();
            perguntas.Add(new PerguntaModel { Codigo = 1, Descricao = "Recentemente nos últimos 7 dias, teve crise de Asma ou bronquite leve (crises com intervalos maiores que 3 meses, compensada com medicamentos por via inalatória) ?", Tipo = 1 });
            perguntas.Add(new PerguntaModel { Codigo = 2, Descricao = "Teste2", Tipo = 1 });
            perguntas.Add(new PerguntaModel { Codigo = 3, Descricao = "Teste3", Tipo = 1 });

            var questionario = new QuestionarioModel { Pessoa = pessoa, Perguntas = perguntas };
            return View(questionario);
        }

        public ActionResult ValidarRespostas(QuestionarioModel questionario)
        {
            questionario.Pessoa.NomeCompleto = "Fulano de tal";
            questionario.Pessoa.Aprovado = true;
            return View("~/Views/Questionario/Resultado.cshtml", questionario.Pessoa);            
        }
    }
}
