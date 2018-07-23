using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class EnderecoEntitieMap : FluentNHibernate.Mapping.ClassMap<EnderecoEntitie>
    {
        public EnderecoEntitieMap()
        {
            Table("tbEndereco");

            Id(item => item.Codigo)
               .Column("codigo");

            Map(item => item.Logradouro)
                .Column("logradouro")
                .Not.Nullable();

            Map(item => item.Numero)
                .Column("numero")
                .Not.Nullable();

            Map(item => item.Complemento)
                .Column("complemento")
                .Not.Nullable();

            Map(item => item.Bairro)
                .Column("bairro")
                .Not.Nullable();

            Map(item => item.Cidade)
                .Column("cidade")
                .Not.Nullable();

            Map(item => item.Estado)
                .Column("estado")
                .Not.Nullable();

            Map(item => item.Cep)
                .Column("cep")
                .Not.Nullable();

            Map(item => item.Ativo)
                .Column("ativo")
                .Not.Nullable();
        }
    }
}
