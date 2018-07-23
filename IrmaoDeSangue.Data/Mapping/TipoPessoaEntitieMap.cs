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

            Map(item => item.Descricao)
                .Column("descricao")
                .Not.Nullable();

        }
    }
}
