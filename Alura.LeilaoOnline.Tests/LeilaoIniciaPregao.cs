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
            var leilao = new Leilao("Van Gogh");
            EstadoLeilao estadoEsperado = EstadoLeilao.LeilaoEmAndamento;

            //Act
            leilao.IniciaPregao();

            //Assert
            Assert.Equal(estadoEsperado, leilao.Estado);
        }
    }
}
