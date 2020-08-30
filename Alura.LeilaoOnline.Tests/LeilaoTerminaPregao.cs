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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);

            //Assert
            var eCapturada = Assert.Throws<InvalidOperationException>(() => /*Act*/leilao.TerminaPregao());
            Assert.Equal(mensagemEsperada, eCapturada.Message);
        }

        [Theory]
        [InlineData(1000, new double[] { 800, 900, 1000, 990 })]
        [InlineData(1000, new double[] { 800, 900, 990, 1000 })]
        [InlineData(800, new double[] { 800 })]
        public void RetornaMaiorValorDeLanceDadoLeilaoComPeloMenosUmCliente(double esperado, double[] ofertas)
        {
            //Arrange
            var modalidade = new MaiorValor();
            var leilao = new Leilao("Van Gogh", modalidade);
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
            Assert.Equal(esperado, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(990, 950, new double[] { 800, 900, 1000, 990 })]
        [InlineData(990, 950,  new double[] { 800, 900, 990, 1000 })]
        [InlineData(1000, 820, new double[] { 800, 1000})]
        public void RetornaValorSuperiorMaisPróximoDoValorDestinoDadoLeilaoNessaModalidade(double esperado, double valorDesejado, double[] ofertas)
        {
            //Arrange
            var modalidade = new OfertaSuperiorMaisProxima(valorDesejado);
            var leilao = new Leilao("Van Gogh", modalidade);
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
            Assert.Equal(esperado, leilao.Ganhador.Valor);
        }
    }
}
