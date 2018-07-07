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

            Map(item => item.Desricao)
                .Column("nome_completo")
                .Not.Nullable();

            Map(item => item.DataNascimento)
                .Column("data_nascimento")
                .Not.Nullable();

            Map(item => item.Sexo)
                .Column("sexo")
                .Not.Nullable();

            Map(item => item.EstadoCivil)
                .Column("estado_civil")
                .Not.Nullable();

            Map(item => item.TipoSanguinio)
                .Column("tipo_sanguineo")
                .Not.Nullable();

            Map(item => item.Email)
                .Column("email")
                .Not.Nullable();

            Map(item => item.AptoParaDoacao)
                .Column("apto_doacao");

            References(item => item.TipoPessoa)
                .Column("codigo_tipo_pessoa")
                .Nullable()
                .Not.LazyLoad();

            Map(item => item.Peso)
                .Column("peso");

            HasMany(quadra => quadra.Doacoes)
                .KeyColumn("codigo")
                .Inverse()
                .AsSet();
        }
    }
}
