using Financas.Calculadoras.Juros.Domain.Builders;
using Xunit;

namespace Financas.Calculadoras.Juros.Domain.Tests
{
    public class CalculadoraDeJurosTests
    {
        [Fact]
        public void CalculadoraDeJuros_DeveCalcularOJuros()
        {
            var resultadoEsperado = 105.10M;
            var calculadoraDeJurosBuilder = new CalculadoraDeJurosBuilder()
                .WithValorInicial(100)
                .WithMeses(5)
                .WithTaxaDeJuros(0.01M);

            var calculadoraDeJuros = calculadoraDeJurosBuilder.Build();
            calculadoraDeJuros.Calcular();

            Assert.Equal(resultadoEsperado, calculadoraDeJuros.Resultado);
        }

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoAQuantidadeDeMesesMesesForIgualAZero()
        {
            var calculadoraDeJurosBuilder = new CalculadoraDeJurosBuilder()
                .WithValorInicial(100)
                .WithMeses(0)
                .WithTaxaDeJuros(0.01M);

            var calculadoraDeJuros = calculadoraDeJurosBuilder.Build();

            Assert.False(calculadoraDeJuros.IsValid());
        }

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoATaxaDeJurosForMenorQueZero()
        {
            var calculadoraDeJurosBuilder = new CalculadoraDeJurosBuilder()
                .WithValorInicial(100)
                .WithMeses(5)
                .WithTaxaDeJuros(-0.01M);

            var calculadoraDeJuros = calculadoraDeJurosBuilder.Build();

            Assert.False(calculadoraDeJuros.IsValid());
        }

        [Fact]
        public void CalculadoraDeJuros_DeveConterErrosQuandoOValorInicialForIgualAZero()
        {
            var calculadoraDeJurosBuilder = new CalculadoraDeJurosBuilder()
                .WithValorInicial(0)
                .WithMeses(5)
                .WithTaxaDeJuros(0.01M);

            var calculadoraDeJuros = calculadoraDeJurosBuilder.Build();

            Assert.False(calculadoraDeJuros.IsValid());
        }
    }
}