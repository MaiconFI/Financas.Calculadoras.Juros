using AutoMapper;
using Financas.Calculadoras.Juros.Domain;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;

namespace Financas.Calculadoras.Juros.Queries.Mappers
{
    public class CalculadoraDeJurosQueriesProfile : Profile
    {
        public CalculadoraDeJurosQueriesProfile()
        {
            CreateMap<CalculadoraDeJuros, CalculoDeJurosDto>().ConvertUsing<CalculadoraDeJurosToCalculoDeJurosDtoConverter>();
            CreateMap<CalculadoraDeJurosDto, CalculadoraDeJuros>().ConvertUsing<CalculadoraDeJurosDtoToCalculadoraDeJurosConverter>();
            CreateMap<TaxaDeJurosDto, CalculoDeJurosDto>().ConvertUsing<TaxaDeJurosDtoToCalculoDeJurosDtoConverter>();
        }
    }
}