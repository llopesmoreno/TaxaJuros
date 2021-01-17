using Microsoft.AspNetCore.Mvc;
using TaxaJurosDocker.Api.Util;
using TaxaJurosDocker.BaseApi.Models;

namespace TaxaJurosDocker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowMeTheCodeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(SuccessRequestResponseDefault<string>), 200)]
        [ProducesResponseType(typeof(BadRequestDefaultModel), 400)]
        [ProducesResponseType(typeof(InternalServerErrorDefaultModel), 500)]
        public IActionResult Get() => this.GetResponse<string>("https://github.com/llopesmoreno/TaxaJuros");        
    }
}
