using Alura.LeilaoOnline.Core.Interfaces;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDesejado { get; }

        public OfertaSuperiorMaisProxima(double valorDesejado)
        {
            ValorDesejado = valorDesejado;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao.Lances
                    .Where(x => x.Valor > ValorDesejado)
                    .DefaultIfEmpty(new Lance(null, 0))
                    .OrderBy(x => x.Valor)
                    .FirstOrDefault();
        }
    }
}
