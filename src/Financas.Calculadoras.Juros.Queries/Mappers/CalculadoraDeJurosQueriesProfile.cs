using AutoMapper;
using Financas.Calculadoras.Juros.Domain;
using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;

namespace Financas.Calculadoras.Juros.Queries.Mappers
{
    public class CalculadoraDeJurosQueriesProfile : Profile
    {
        public CalculadoraDeJurosQueriesProfile()
        {
            CreateMap<CalculadoraDeJuros, CalculoDeJurosDto>().ConvertUsing<CalculadoraDeJurosToCalculoDeJurosDtoConverter>();
        }
    }
}