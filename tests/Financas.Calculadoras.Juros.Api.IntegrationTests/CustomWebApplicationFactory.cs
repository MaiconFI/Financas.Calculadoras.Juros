using Financas.Calculadoras.Juros.Clients;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Financas.Calculadoras.Juros.Api.IntegrationTests
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceDescriptor = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(ITaxaDeJurosClient));
                services.Remove(serviceDescriptor);
                services.AddScoped<ITaxaDeJurosClient, MockTaxaDeJurosClient>();
            });
        }
    }
}