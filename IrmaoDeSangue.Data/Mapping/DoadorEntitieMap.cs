using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class DoadorEntitieMap : FluentNHibernate.Mapping.ClassMap<DoadorEntitie>
    {
        public DoadorEntitieMap()
        {
            Table("tbPessoa");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Desricao)
                .Column("nome_completo")
                .Not.Nullable();

            References(item => item.DataNascimento)
                .Column("data_nascimento")
                .Not.Nullable();

            References(item => item.Sexo)
                .Column("sexo")
                .Not.Nullable();

            References(item => item.EstadoCivil)
                .Column("estado_civil")
                .Not.Nullable();

            References(item => item.TipoSanguinio)
                .Column("tipo_sanguinio")
                .Not.Nullable();

            References(item => item.Email)
                .Column("email")
                .Not.Nullable();

            References(item => item.AptoParaDoacao)
                .Column("apto_doacao");

            References(item => item.TipoPessoa)
                .Column("codigo_tipo_pessoa")
                .Nullable()
                .Not.LazyLoad();

            References(item => item.Peso)
                .Column("peso");
        }
    }
}
