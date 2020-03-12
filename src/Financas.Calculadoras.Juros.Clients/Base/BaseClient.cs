using Financas.Calculadoras.Juros.Dtos.Base;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Clients.Base
{
    public abstract class BaseClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _name;

        protected BaseClient(IHttpClientFactory httpClientFactory, string name)
        {
            _httpClientFactory = httpClientFactory;
            _name = name;
        }

        protected abstract TResult DeserializreResult<TResult>(string result);

        protected async Task<TResult> GetAsync<TResult>(string endpoint, CancellationToken cancellationToken)
            where TResult : BaseDto, new()
        {
            var client = GetClient();

            try
            {
                var response = await client.GetAsync(endpoint, cancellationToken);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return DeserializreResult<TResult>(json);
                }

                return GetErrorMessage<TResult>(response.ToString());
            }
            catch (Exception ex)
            {
                var errorMessage = string.IsNullOrWhiteSpace(ex.InnerException?.Message) ? ex.InnerException?.Message : ex.Message;
                return GetErrorMessage<TResult>(errorMessage);
            }
        }

        protected abstract TResult GetErrorMessage<TResult>(string message)
            where TResult : BaseDto, new();

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient(_name);
            client.Timeout = TimeSpan.FromSeconds(180);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }
    }
}