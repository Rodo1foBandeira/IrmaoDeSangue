using IrmaoDeSangue.Data;
using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business
{
    public class PerguntaBusiness
    {
        protected PerguntaData _perguntaData { get; set; }

        public IList<PerguntaEntitie> RecuperaPerguntas()
        {
            return _perguntaData.RecuperarPerguntas();
        }
    }
}
