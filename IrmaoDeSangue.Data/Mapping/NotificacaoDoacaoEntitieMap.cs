using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class NotificacaoDoacaoEntitieMap : FluentNHibernate.Mapping.ClassMap<NotificacaoDoacaoEntitie>
    {
        public NotificacaoDoacaoEntitieMap()
        {
            Table("tbNotificacaoParaDoacao");

            Id(item => item.Codigo)
               .Column("codigo");

            References(item => item.Doador)
                .Column("codigo_pessoa_doador")
                .Nullable()
                .Not.LazyLoad();

            References(item => item.Agendamento)
                .Column("codigo_agendamento")
                .Nullable()
                .Not.LazyLoad();

            References(item => item.DataNotificacao)
                .Column("data_notificacao")
                .Not.Nullable();

            References(item => item.ChaveAutenticacao)
                .Column("chave_autenticacao")
                .Not.Nullable();

            References(item => item.Confirmado)
                .Column("confirmado")
                .Not.Nullable();

            References(item => item.DataConfirmacao)
                .Column("data_confirmacao")
                .Not.Nullable();
        }
    }
}
