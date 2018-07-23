using IrmaoDeSangue.Entities;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data
{
    public class DoadorData : BaseData
    {
        public DoadorData()
        { 

        }

        public IList<DoadorEntitie> RecuperaDoadoresIndefinidos()
        {
            var criteria = GetSession().QueryOver<DoadorEntitie>()
                .Where(x => 
                    (x.AptoParaDoacaoPermanente == null || x.AptoParaDoacaoPermanente.Value) 
                    && (x.AptoParaDoacaoTemporariamente == null || !x.AptoParaDoacaoTemporariamente.Value))                    
                .JoinQueryOver<ConfirmacaoDoacaoEntitie>(x => x.Doacoes, JoinType.LeftOuterJoin)
                .TransformUsing(Transformers.DistinctRootEntity);

            return criteria.List<DoadorEntitie>();
        }

        public IList<DoadorEntitie> RecuperaPossiveisDoadores()
        {
            DoadorEntitie doadorAlias = null;

            var criteria = GetSession().QueryOver<DoadorEntitie>(() => doadorAlias)
            .Where(x => x.AptoParaDoacaoPermanente == true && x.AptoParaDoacaoTemporariamente == true)            
            .Inner.JoinQueryOver(() => doadorAlias.Enderecos)
            .Left.JoinQueryOver(() => doadorAlias.Doacoes);

            return criteria.List<DoadorEntitie>();
        }        
    }
}
