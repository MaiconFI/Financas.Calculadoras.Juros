﻿using Financas.Calculadoras.Juros.Dtos.CalculoDeJuros;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Financas.Calculadoras.Juros.Api.IntegrationTests
{
    public class CalculadoraDeJurosTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public CalculadoraDeJurosTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/v1/calculajuros?valorinicial=100&meses=5 ")]
        public async Task DeveRetornarOCalculoDeJuros(string url)
        {
            var resultadoEsperado = new CalculoDeJurosDto() { Resultado = 105.10M };
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var xpto = await response.Content.ReadAsStringAsync();
            var resultado = JsonSerializer.Deserialize<CalculoDeJurosDto>(xpto);

            Assert.Equal(resultadoEsperado.Resultado, resultado.Resultado);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}