using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class TipoPessoaEntitieMap : FluentNHibernate.Mapping.ClassMap<TipoPessoaEntitie>
    {
        public TipoPessoaEntitieMap()
        {
            Table("tbTipoPessoa");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Desricao)
                .Column("nome_completo")
                .Not.Nullable();

        }
    }
}
