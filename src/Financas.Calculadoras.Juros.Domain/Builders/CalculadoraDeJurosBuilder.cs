namespace Financas.Calculadoras.Juros.Domain.Builders
{
    public class CalculadoraDeJurosBuilder
    {
        private int Meses;
        private decimal TaxaDeJuros;
        private decimal ValorInicial;

        public CalculadoraDeJuros Build() => new CalculadoraDeJuros(ValorInicial, Meses, TaxaDeJuros);

        public CalculadoraDeJurosBuilder WithMeses(int meses)
        {
            Meses = meses;
            return this;
        }

        public CalculadoraDeJurosBuilder WithTaxaDeJuros(decimal taxaDeJuros)
        {
            TaxaDeJuros = taxaDeJuros;
            return this;
        }

        public CalculadoraDeJurosBuilder WithValorInicial(decimal valorInicial)
        {
            ValorInicial = valorInicial;
            return this;
        }
    }
}