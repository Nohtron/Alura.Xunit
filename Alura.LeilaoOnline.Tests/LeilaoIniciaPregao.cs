using Alura.LeilaoOnline.Core;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoIniciaPregao
    {

        [Fact]
        public void EstadoDeUmLeilaoIgualLeilaoEmAndamentoDadoUmLeilaoIniciado()
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
            EstadoLeilao estadoEsperado = EstadoLeilao.LeilaoEmAndamento;

            //Act
            leilao.IniciaPregao();

            //Assert
            Assert.Equal(estadoEsperado, leilao.Estado);
        }
    }
}
