using AutoMapper;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;

namespace Financas.Calculadoras.Juros.Queries.Mappers
{
    public class TaxaDeJurosDtoToCalculoDeJurosDtoConverter : ITypeConverter<TaxaDeJurosDto, CalculoDeJurosDto>
    {
        public CalculoDeJurosDto Convert(TaxaDeJurosDto source, CalculoDeJurosDto destination, ResolutionContext context)
        {
            var dto = new CalculoDeJurosDto();
            dto.AddError(source.Errors);

            return dto;
        }
    }
}