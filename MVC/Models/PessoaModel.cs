using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class PessoaModel
    {
        public int Codigo { get; set; }
        public string NomeCompleto { get; set; }
        public bool Aprovado { get; set; }
        public string Alerta { get; set; }
    }
}
