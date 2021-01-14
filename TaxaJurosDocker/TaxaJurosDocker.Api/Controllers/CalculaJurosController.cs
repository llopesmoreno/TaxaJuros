using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace TaxaJurosDocker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(decimal valorinicial, int meses)
        {
            using var client = new System.Net.Http.HttpClient();
            var request = new System.Net.Http.HttpRequestMessage
            {
                RequestUri = new Uri("http://taxajurosdocker.resourcesapi/taxajuros") // ASP.NET 3 (VS 2019 only)            
            };
            var response = await client.SendAsync(request);
            return Ok(await response.Content.ReadAsStringAsync());
        }
    }
}
