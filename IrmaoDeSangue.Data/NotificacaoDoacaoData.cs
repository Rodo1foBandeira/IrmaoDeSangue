using IrmaoDeSangue.Entities;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class NotificacaoDoacaoData : BaseData
    {
        public NotificacaoDoacaoEntitie RecuperaPorCodigoEChaveAutenticacao(int codigo, string chaveAutenticacao)
        {
            var criteria = GetSession().CreateCriteria<NotificacaoDoacaoEntitie>("NotificacaoDoacao");
            
            criteria.CreateCriteria("NotificacaoDoacao.Agendamento", "Agendamento", JoinType.InnerJoin);
            criteria.CreateCriteria("NotificacaoDoacao.Doador", "Doador", JoinType.InnerJoin);
            criteria.CreateCriteria("Agendamento.Hemonucleo", "Hemonucleo", JoinType.InnerJoin);
            criteria.Add(Restrictions.Eq("Doador.Codigo", codigo));
            criteria.Add(Restrictions.Eq("NotificacaoDoacao.ChaveAutenticacao", chaveAutenticacao));

            return criteria.UniqueResult<NotificacaoDoacaoEntitie>();
        }
    }
}
