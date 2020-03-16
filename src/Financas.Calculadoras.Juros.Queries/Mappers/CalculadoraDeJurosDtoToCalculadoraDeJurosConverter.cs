using AutoMapper;
using Financas.Calculadoras.Juros.Domain;
using Financas.Calculadoras.Juros.Domain.Builders;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;

namespace Financas.Calculadoras.Juros.Queries.Mappers
{
    public class CalculadoraDeJurosDtoToCalculadoraDeJurosConverter : ITypeConverter<CalculadoraDeJurosDto, CalculadoraDeJuros>
    {
        public CalculadoraDeJuros Convert(CalculadoraDeJurosDto source, CalculadoraDeJuros destination, ResolutionContext context)
        {
            var builder = new CalculadoraDeJurosBuilder()
                .WithMeses(source.Meses)
                .WithTaxaDeJuros(source.TaxaDeJuros)
                .WithValorInicial(source.ValorInicial);

            return builder.Build();
        }
    }
}