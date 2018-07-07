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

            Map(item => item.Descricao)
                .Column("nome")
                .Not.Nullable();

            Map(item => item.Atendimento)
                .Column("atendimento")
                .Not.Nullable();

            Map(item => item.Responsavel)
                .Column("responsavel")
                .Not.Nullable();

            Map(item => item.Telefone)
                .Column("telefone")
                .Not.Nullable();

            Map(item => item.Email)
                .Column("email")
                .Not.Nullable();

            Map(item => item.Site)
                .Column("site")
                .Not.Nullable();
        }

    }
}
