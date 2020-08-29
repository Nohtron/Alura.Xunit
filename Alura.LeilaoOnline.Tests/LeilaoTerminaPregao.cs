using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.Tests
{
    public class LeilaoTerminaPregao
    {
        [Fact]
        public void RetornaZeroDadoLeilaoSemLances()
        {
            //Arrange
            double expected = 0;
            var leilao = new Leilao("Van Gogh");
            leilao.IniciaPregao();

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(expected, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoQueUmLeilaoEhFinalizadoSemSerIniciado()
        {
            //Arrange
            var mensagemEsperada = "Não é possível finalizar o pregão sem o mesmo ter sido iniciado.";
            var leilao = new Leilao("Van Gogh");

            //Assert
            var exceptionCapturada = Assert.Throws<InvalidOperationException>(() => /*Act*/leilao.TerminaPregao());
            Assert.Equal(mensagemEsperada, exceptionCapturada.Message);
        }

        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(1000, new double[] { 800, 900, 990, 1000 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDeLanceDadoLeilaoComPeloMenosUmCliente(double expected, double[] ofertas)
        {
            //Arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();
            for (int i = 0; i < ofertas.Length; i++)
            {
                if (i % 2 == 0)
                    leilao.RecebeLance(fulano, ofertas[i]);
                else
                    leilao.RecebeLance(maria, ofertas[i]);
            }

            //Act
            leilao.TerminaPregao();

            //Assert
            Assert.Equal(expected, leilao.Ganhador.Valor);
        }
    }
}
