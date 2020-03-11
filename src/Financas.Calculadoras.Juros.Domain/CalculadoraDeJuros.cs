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

        public override decimal Calcular()
        {
            var valorFinal = ValorInicial * (decimal)Math.Pow((double)(1 + TaxaDeJuros), Meses);
            return decimal.Parse(valorFinal.ToString("##.00"));
        }

        private void ValidarMeses(decimal meses)
        {
            if (meses < default(decimal))
                throw new ArgumentException("A quantidade de meses deve ser maior quer zero.");
        }

        private void ValidarTaxaDeJuros(decimal taxaDeJuros)
        {
            if (taxaDeJuros < default(decimal))
                throw new ArgumentException("A taxa de juros deve ser maior que zero.");
        }

        private void ValidarValorInicial(decimal valorInicial)
        {
            if (valorInicial < default(decimal))
                throw new ArgumentException("O valor inicial deve ser maior quer zero.");
        }
    }
}