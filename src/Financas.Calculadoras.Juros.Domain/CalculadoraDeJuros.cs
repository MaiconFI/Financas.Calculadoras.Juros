using System;

namespace Financas.Calculadoras.Juros.Domain
{
    public class CalculadoraDeJuros : Calculadora
    {
        public CalculadoraDeJuros(decimal valorInicial, int meses, decimal taxaDeJuros)
        {
            ValidarValorInicial(valorInicial);
            ValidarMeses(meses);
            ValidarTaxaDeJuros(taxaDeJuros);

            ValorInicial = valorInicial;
            Meses = meses;
            TaxaDeJuros = taxaDeJuros;
        }

        public int Meses { get; private set; }
        public decimal TaxaDeJuros { get; private set; }
        public decimal ValorInicial { get; private set; }

        public override void Calcular()
        {
            var valorFinal = ValorInicial * (decimal)Math.Pow((double)(1 + TaxaDeJuros), Meses);
            Resultado = decimal.Parse(valorFinal.ToString("##.00"));
        }

        private void ValidarMeses(decimal meses)
        {
            if (meses <= default(decimal))
                AddError("A quantidade de meses deve ser maior quer zero.");
        }

        private void ValidarTaxaDeJuros(decimal taxaDeJuros)
        {
            if (taxaDeJuros < default(decimal))
                AddError("A taxa de juros deve ser maior ou igual a zero.");
        }

        private void ValidarValorInicial(decimal valorInicial)
        {
            if (valorInicial <= default(decimal))
                AddError("O valor inicial deve ser maior quer zero.");
        }
    }
}