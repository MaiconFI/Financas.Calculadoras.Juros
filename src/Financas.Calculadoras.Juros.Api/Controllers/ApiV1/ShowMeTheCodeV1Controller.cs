using Financas.Calculadoras.Juros.Api.Controllers.Base.ApiV1;
using Financas.Calculadoras.Juros.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Financas.Calculadoras.Juros.Api.Controllers.ApiV1
{
    [Route("v{version:apiVersion}/showmethecode")]
    public class ShowMeTheCodeV1Controller : ApiV1BaseController
    {
        [HttpGet]
        public IActionResult Get()
            => Ok(new ShowMeTheCodeViewModel());
    }
}