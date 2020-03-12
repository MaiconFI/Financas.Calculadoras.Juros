using AutoMapper;
using Financas.Calculadoras.Juros.Domain;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;

namespace Financas.Calculadoras.Juros.Queries.Mappers
{
    public class CalculadoraDeJurosToCalculoDeJurosDtoConverter : ITypeConverter<CalculadoraDeJuros, CalculoDeJurosDto>
    {
        public CalculoDeJurosDto Convert(CalculadoraDeJuros source, CalculoDeJurosDto destination, ResolutionContext context)
            => new CalculoDeJurosDto()
            {
                Resultado = source.Resultado
            };
    }
}