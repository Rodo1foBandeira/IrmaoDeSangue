using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class HemonucleoEntitieMap : FluentNHibernate.Mapping.ClassMap<HemonucleoEntitie>
    {
        public HemonucleoEntitieMap()
        {
            Table("tbHemonucleo");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Desricao)
                .Column("nome")
                .Not.Nullable();

            References(item => item.Atendimento)
                .Column("atendimento")
                .Not.Nullable();

            References(item => item.Responsavel)
                .Column("responsavel")
                .Not.Nullable();

            References(item => item.Telefone)
                .Column("telefone")
                .Not.Nullable();

            References(item => item.Email)
                .Column("email")
                .Not.Nullable();

            References(item => item.Site)
                .Column("site")
                .Not.Nullable();
        }

    }
}
