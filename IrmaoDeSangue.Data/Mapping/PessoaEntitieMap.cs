using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class PessoaEntitieMap : FluentNHibernate.Mapping.ClassMap<PessoaEntitie>
    {
        public PessoaEntitieMap()
        {
            Table("tbPessoa");

            Id(item => item.Codigo)
               .Column("codigo");

            Map(item => item.Descricao)
                .Column("nome_completo")
                .Not.Nullable();

            Map(item => item.DataNascimento)
                .Column("data_nascimento")
                .Nullable();

            Map(item => item.Sexo)
                .Column("sexo")
                .Not.Nullable();

            Map(item => item.EstadoCivil)
                .Column("estado_civil")
                .Nullable();

            Map(item => item.Email)
                .Column("email")
                .Nullable();

            Map(item => item.Telefone)
                .Column("telefone")
                .Nullable();

            References(item => item.TipoPessoa)
                .Column("codigo_tipo_pessoa")
                .Nullable()
                .Not.LazyLoad();

            /*HasMany(item => item.Enderecos)
                .KeyColumn("codigo_pessoa");*/
        }
    }
}
