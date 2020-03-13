using Financas.Calculadoras.Juros.Clients.Base;
using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Clients
{
    public class TaxaDeJurosClient : BaseClient, ITaxaDeJurosClient
    {
        public TaxaDeJurosClient(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory, "TaxaDeJurosV1")
        {
        }

        public async Task<TaxaDeJurosDto> GetAsync(CancellationToken cancellationToken)
            => await GetAsync<TaxaDeJurosDto>("taxaJuros", cancellationToken);

        protected override TResult DeserializreResult<TResult>(string result) => JsonSerializer.Deserialize<TResult>(result);

        protected override TResult GetErrorMessage<TResult>(string message)
            => new TResult
            {
                Errors = { $"Erro ao consultar a API de Taxa de Juros. Mensagem: {message}" }
            };
    }
}