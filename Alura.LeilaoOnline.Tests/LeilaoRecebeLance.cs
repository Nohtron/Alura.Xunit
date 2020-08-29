using Alura.LeilaoOnline.Core;
using System.Linq;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(4, new double[] { 800, 900, 1000, 990 })]
        [InlineData(3, new double[] { 800, 990, 1000 })]
        [InlineData(1, new double[] { 800 })]
        public void NaoPermiteNovosLancesDadoLeilaoTerminado(int quantidadeEsperada, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i%2 == 0)
                    leilao.RecebeLance(fulano, ofertas[i]);
                else
                    leilao.RecebeLance(maria, ofertas[i]);
            }
            leilao.TerminaPregao();

            //Act
            leilao.RecebeLance(fulano, 1000);

            //Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }

        [Theory]
        [InlineData(0, new double[] { 800, 900, 1000, 990 })]
        [InlineData(0, new double[] { 800, 990, 1000 })]
        [InlineData(0, new double[] { 800 })]
        public void NaoPermiteNovosLancesDadoLeilaoNaoIniciado(int quantidadeEsperada, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);

            //Act
            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                    leilao.RecebeLance(fulano, ofertas[i]);
                else
                    leilao.RecebeLance(maria, ofertas[i]);
            }

            //Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }

        [Fact]
        public void NaoPermiteNovoLanceDeUmClienteDadoQueUltimoLanceFoiDesseMesmoCliente()
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            leilao.RecebeLance(fulano, 800);
            var quantidadeEsperada = 1;

            //Act
            leilao.RecebeLance(fulano, 100);

            //Assert
            Assert.Equal(quantidadeEsperada, leilao.Lances.Count());
        }
    }
}
