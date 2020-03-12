using Financas.Calculadoras.Juros.Dtos.TaxaDeJuros;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Clients
{
    public interface ITaxaDeJurosClient
    {
        Task<TaxaDeJurosDto> GetAsync(CancellationToken cancellationToken);
    }
}