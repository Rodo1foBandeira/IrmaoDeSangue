using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class QuestionarioModel
    {
        public PessoaModel Pessoa { get; set; }
        public List<PerguntaModel> Perguntas { get; set; }
    }
}
