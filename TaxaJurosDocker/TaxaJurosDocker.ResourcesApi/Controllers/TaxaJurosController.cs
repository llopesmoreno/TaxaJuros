using Microsoft.AspNetCore.Mvc;

namespace TaxaJurosDocker.ResourcesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public double Get()
        {
            return 0.01d;
        }
    }
}
