using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class AgendamentoEntitieMap : FluentNHibernate.Mapping.ClassMap<AgendamentoEntitie>
    {
        public AgendamentoEntitieMap()
        {
            Table("tbAgendamentoDoacao");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Data)
                .Column("data")
                .Not.Nullable();

            References(item => item.Hemonucleo)
                .Column("codigo_hemonucleo")
                .Not.Nullable()
                .Not.LazyLoad();

            References(item => item.StatusProcessamento)
                .Column("status_processamento")
                .Not.Nullable();

            References(item => item.MaximoDoadores)
                .Column("maximo_doadores")
                .Not.Nullable();
        }

    }
}
