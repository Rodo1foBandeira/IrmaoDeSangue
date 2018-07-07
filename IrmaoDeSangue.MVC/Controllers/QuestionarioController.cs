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
            var lista = new List<QuestionarioModels>();
            lista.Add(new QuestionarioModels { Codigo = 1, Descricao = "Teste", Tipo = 1});
            lista.Add(new QuestionarioModels { Codigo = 2, Descricao = "Teste2", Tipo = 1});
            lista.Add(new QuestionarioModels { Codigo = 3, Descricao = "Teste3", Tipo = 1});
            return View(lista);
        }

        public ActionResult Visualizar()
        {
            return View();
        }

    }
}
