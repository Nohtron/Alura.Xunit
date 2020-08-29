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
            var leilao = new Leilao("Van Gogh");

            //Assert
            Assert.Equal(estadoEsperado, leilao.Estado);
        }
    }
}
