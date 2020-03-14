using Financas.Calculadoras.Juros.Clients;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Api.IntegrationTests
{
    public class MockTaxaDeJurosClient : ITaxaDeJurosClient
    {
        public Task<TaxaDeJurosDto> GetAsync(CancellationToken cancellationToken)
            => Task.FromResult(new TaxaDeJurosDto() { Valor = 0.01M });
    }
}