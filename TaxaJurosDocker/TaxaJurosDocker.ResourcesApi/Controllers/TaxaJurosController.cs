using Microsoft.AspNetCore.Mvc;

namespace TaxaJurosDocker.ResourcesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public decimal Get()
        {
            return 0.01m;
        }
    }
}
