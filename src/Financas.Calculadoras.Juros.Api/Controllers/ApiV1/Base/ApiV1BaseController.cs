using Financas.Calculadoras.Juros.Dtos.Base;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Financas.Calculadoras.Juros.Api.Controllers.Base.ApiV1
{
    [ApiController]
    [ApiVersion("1")]
    public abstract class ApiV1BaseController : ControllerBase
    {
        protected IActionResult TratarRetorno(BaseDto dto)
            => dto.Errors?.Any() ?? true
                ? (IActionResult)BadRequest(dto)
                : Ok(dto);
    }
}