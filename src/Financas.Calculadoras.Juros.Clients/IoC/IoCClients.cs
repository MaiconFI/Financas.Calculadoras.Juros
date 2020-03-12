using Microsoft.Extensions.DependencyInjection;

namespace Financas.Calculadoras.Juros.Clients.IoC
{
    public class IoCClients
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<ITaxaDeJurosClient, TaxaDeJurosClient>();
        }
    }
}