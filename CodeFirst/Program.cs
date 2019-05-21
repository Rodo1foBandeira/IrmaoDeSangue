using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using IrmaoDeSangue.Data.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;

namespace CodeFirst
{
    class Program
    {
        private static ISessionFactory _sessionFactory;

        static void Main(string[] args)
        {
            var configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(@"Data Source=arasrvvirssd004,1433;Initial Catalog=cast_isangue_dsv;Integrated Security=false;User ID=cast_isangue;Password=k5tdger4;"))
                .Mappings(m => m.FluentMappings                   

                    .AddFromAssemblyOf<TipoPessoaEntitieMap>()
                    .AddFromAssemblyOf<PessoaEntitieMap>()

                    .AddFromAssemblyOf<HemonucleoEntitieMap>()
                    .AddFromAssemblyOf<AgendamentoEntitieMap>()

                    .AddFromAssemblyOf<PerguntaEntitieMap>()
                    .AddFromAssemblyOf<ConfirmacaoDoacaoEntitieMap>()
                    .AddFromAssemblyOf<DoadorEntitieMap>()
                    .AddFromAssemblyOf<NotificacaoDoacaoEntitieMap>()

                    .AddFromAssemblyOf<EnderecoEntitieMap>()
                )
                .BuildConfiguration();

            var exporter = new SchemaExport(configuration);
            exporter.Execute(true, true, false);

            _sessionFactory = configuration.BuildSessionFactory();
        }
    }
}
