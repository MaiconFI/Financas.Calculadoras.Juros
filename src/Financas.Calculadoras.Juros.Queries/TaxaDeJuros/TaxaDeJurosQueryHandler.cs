using Financas.Calculadoras.Juros.Clients;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Queries.TaxaDeJuros
{
    public class TaxaDeJurosQueryHandler : IRequestHandler<TaxaDeJurosQuery, TaxaDeJurosDto>
    {
        private readonly ITaxaDeJurosClient _taxaDeJurosClient;

        public TaxaDeJurosQueryHandler(ITaxaDeJurosClient taxaDeJurosClient)
        {
            _taxaDeJurosClient = taxaDeJurosClient;
        }

        public async Task<TaxaDeJurosDto> Handle(TaxaDeJurosQuery request, CancellationToken cancellationToken)
            => await _taxaDeJurosClient.GetAsync(cancellationToken);
    }
}