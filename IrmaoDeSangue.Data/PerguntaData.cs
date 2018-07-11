using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class PerguntaData : BaseData
    {
        public PerguntaData()
        {

        }

        public IList<PerguntaEntitie> RecuperarPerguntas()
        {
            var criteria = GetSession().CreateCriteria<PerguntaEntitie>("PerguntaEntitie");
            return criteria.List<PerguntaEntitie>();
        }
    }
}
