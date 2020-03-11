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

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoAQuantidadeDeMesesMesesForIgualAZero()
        {
            var calculadoraDeJuros = new CalculadoraDeJuros(valorInicial: 100, meses: 0, taxaDeJuros: 0.01M);

            Assert.False(calculadoraDeJuros.IsValid());
        }

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoATaxaDeJurosForMenorQueZero()
        {
            var calculadoraDeJuros = new CalculadoraDeJuros(valorInicial: 100, meses: 5, taxaDeJuros: -0.01M);

            Assert.False(calculadoraDeJuros.IsValid());
        }

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoOValorInicialForIgualAZero()
        {
            var calculadoraDeJuros = new CalculadoraDeJuros(valorInicial: 0, meses: 5, taxaDeJuros: 0.01M);

            Assert.False(calculadoraDeJuros.IsValid());
        }
    }
}