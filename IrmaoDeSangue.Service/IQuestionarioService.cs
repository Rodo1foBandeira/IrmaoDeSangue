using IrmaoDeSangue.Business;
using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IrmaoDeSangue.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IQuestionarioService" in both code and config file together.
    [ServiceContract]
    public interface IQuestionarioService
    {
        [OperationContract]
        IList<PerguntaEntitie> RecuperarPerguntas();
    }
}
