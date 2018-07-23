using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Data.Mapping
{
    public class DoadorEntitieMap : FluentNHibernate.Mapping.SubclassMap<DoadorEntitie>
    {
        public DoadorEntitieMap()            
        {
            Table("tbDoador");

            KeyColumn("codigo");

            Map(item => item.TipoSanguinio)
                .Column("tipo_sanguineo")
                .Not.Nullable();

            Map(item => item.AptoParaDoacaoPermanente)
                .Column("apto_doacao_permanente");

            Map(item => item.AptoParaDoacaoTemporariamente)
                .Column("apto_doacao_temporariamente");

            Map(item => item.Peso)
                .Column("peso");

            HasMany(quadra => quadra.Doacoes)
                .KeyColumn("codigo")
                .Inverse();
        }
    }
}
