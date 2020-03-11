using Xunit;

namespace Financas.Calculadoras.Juros.Domain.Tests
{
    public class CalculadoraDeJurosTests
    {
        [Fact]
        public void CalculadoraDeJuros_DeveCalcularOJuros()
        {
            var resultadoEsperado = 105.10M;
            var calculadoraDeJuros = new CalculadoraDeJuros(valorInicial: 100, meses: 5, taxaDeJuros: 0.01M);
            var resultado = calculadoraDeJuros.Calcular();

            Assert.Equal(resultadoEsperado, resultado);
        }
    }
}