using Financas.Calculadoras.Juros.Api.Controllers.Base.ApiV1;
using Financas.Calculadoras.Juros.Queries.CalculoDeJuros;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Financas.Calculadoras.Juros.Api.Controllers.ApiV1
{
    [Route("v{version:apiVersion}/calculajuros")]
    public class CalculadoraDeJurosV1Controller : ApiV1BaseController
    {
        private readonly IMediator _mediator;

        public CalculadoraDeJurosV1Controller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery]CalcularJurosQuery calcularJurosQuery, CancellationToken cancellationToken)
        {
            return TratarRetorno(await _mediator.Send(calcularJurosQuery, cancellationToken));
        }
    }
}