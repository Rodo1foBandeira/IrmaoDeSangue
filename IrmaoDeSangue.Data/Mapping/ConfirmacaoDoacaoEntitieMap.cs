using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class ConfirmacaoDoacaoEntitieMap : FluentNHibernate.Mapping.ClassMap<ConfirmacaoDoacaoEntitie>
    {
        public ConfirmacaoDoacaoEntitieMap()
        {
            Table("tbConfirmacaoDoacao");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Notificacao)
                .Column("codigo_notificacao")
                .Not.Nullable();

            Map(item => item.DataEnvioSolicitacaoConfirmacao)
                .Column("data_envio_solicitacao_confirmacao")
                .Not.Nullable();

            Map(item => item.DataConfirmacaoDoacao)
                .Column("data_doacao")
                .Nullable();

            Map(item => item.DoacaoRealizada)
                .Column("doacao_realizada")
                .Nullable();
        }
    }
}
