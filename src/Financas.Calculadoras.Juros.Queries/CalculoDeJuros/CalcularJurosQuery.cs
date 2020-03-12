using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;
using MediatR;

namespace Financas.Calculadoras.Juros.Queries.CalculoDeJuros
{
    public class CalcularJurosQuery : IRequest<CalculoDeJurosDto>
    {
        public int Meses { get; set; }
        public decimal ValorInicial { get; set; }
    }
}