using System;
using Xunit;
using Alura.LeilaoOnline.Core;

namespace Alura.LeilaoOnline.Tests
{
    public class LanceCtor
    {
        [Fact]
        public void LancaArgumentExceptionDadoLanceComValorNegativo()
        {
            //Arrange
            var valorNegativo = -100;
            var mensagemEsperada = "Valor do lance deve ser igual ou maior que zero.";

            //Assert
            var exceptionCapturada = Assert.Throws<ArgumentException>(() => /*Act*/ new Lance(null, valorNegativo));
            Assert.Equal(mensagemEsperada, exceptionCapturada.Message);
        }

    }
}
