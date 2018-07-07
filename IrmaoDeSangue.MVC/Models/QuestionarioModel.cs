using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrmaoDeSangue.MVC.Models
{
    public class QuestionarioModel
    {
        public PessoaModel Pessoa { get; set; }
        public List<PerguntaModel> Perguntas { get; set; }
    }
}