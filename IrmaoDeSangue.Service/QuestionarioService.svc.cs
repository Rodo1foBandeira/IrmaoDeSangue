using IrmaoDeSangue.Entities;
using IrmaoDeSangue.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IrmaoDeSangue.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "QuestionarioService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select QuestionarioService.svc or QuestionarioService.svc.cs at the Solution Explorer and start debugging.
    public class QuestionarioService : IQuestionarioService
    {
        public PerguntaBusiness _perguntaBusiness { get; set; }

        public QuestionarioService()
        {
            _perguntaBusiness = new PerguntaBusiness();
        }

        public IList<PerguntaEntitie> RecuperarPerguntas()
        {
            return _perguntaBusiness.RecuperaPerguntas();
        }
    }
}
