using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoCtor
    {
        [Fact]
        public void EstadoDeUmLeilaoIgualLeilaoAntesDoPregaoDadoUmLeilaoCriadoMasNaoIniciado()
        {
            //Arrange
            EstadoLeilao estadoEsperado = EstadoLeilao.LeilaoAntesDoPregao;

            //Act
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Assert
            Assert.Equal(estadoEsperado, leilao.Estado);
        }
    }
}
