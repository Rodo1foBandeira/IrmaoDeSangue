using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PerguntaModel
    {
        public int Codigo { get; set; }
        public String Descricao { get; set; }
        public int Tipo { get; set; }
        public bool Resposta { get; set; }
    }
}
