using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class PerguntaEntitieMap : FluentNHibernate.Mapping.ClassMap<PerguntaEntitie>
    {
        public PerguntaEntitieMap()
        {
            Table("tbPergunta");

            Id(item => item.Codigo)
               .Column("codigo");

            Map(item => item.Descricao)
                .Column("descricao")
                .Nullable();

            Map(item => item.TipoPergunta)
                .Column("tipo")
                .Nullable();
        }
    }
}
