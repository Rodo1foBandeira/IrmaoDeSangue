using IrmaoDeSangue.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrmaoDeSangue.Business.Sorteio
{
    public class SorteioDoadorBusiness
    {
        public static List<DoadorEntitie> SortearDoadoresValidos(IList<DoadorEntitie> collectionDoadoesValidos, int quantidadeSorteados)
        {
            var listaDoadoesValidos = collectionDoadoesValidos.ToList();

            int maxRangeNumeroRandom = listaDoadoesValidos.Count + 100;
            
            listaDoadoesValidos.ToList().ForEach(doador => 
            {
                int chave = new Random().Next(maxRangeNumeroRandom);
                
                while (listaDoadoesValidos.Exists(x => x.ChaveSorteio == chave))
                {
                    chave = new Random().Next(maxRangeNumeroRandom);
                }

                doador.ChaveSorteio = chave;
            });

            listaDoadoesValidos = listaDoadoesValidos.OrderBy(x => x.QuantidadeDoacoes).ThenBy(x => x.ChaveSorteio).ToList();

            return listaDoadoesValidos.Take(quantidadeSorteados).ToList();
        }
    }
}
