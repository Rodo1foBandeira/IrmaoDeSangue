﻿using IrmaoDeSangue.Business;
using IrmaoDeSangue.Entities;
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
            var perguntaBuss = new PerguntaBusiness();
            var perg = perguntaBuss.RecuperaPerguntas();

            var perguntas = new List<PerguntaModel>();
            perg.ToList<PerguntaEntitie>().ForEach(x =>
            {
                perguntas.Add(new PerguntaModel { Codigo = x.Codigo, Descricao = x.Descricao, Tipo = (int)x.TipoPergunta });
            });

            var pessoa = new PessoaModel { Codigo = idPessoa, NomeCompleto = "Todo: pegar no banco" };
            
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
