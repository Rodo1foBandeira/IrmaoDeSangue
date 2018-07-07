using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrmaoDeSangue.MVC.Models
{
    public class PerguntaModel
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public int Tipo { get; set; }
        public bool Resposta { get; set; }
    }
}