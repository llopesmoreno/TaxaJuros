using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxaJurosDocker.Api.Util;
using TaxaJurosDocker.BaseApi.Models;
using TaxaJurosDocker.Application.Util;
using TaxaJurosDocker.Application.CalculoJuros;

namespace TaxaJurosDocker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculaJurosController : ControllerBase
    {
        private readonly INotifier _notifier;
        private readonly IMediator _mediator;

        public CalculaJurosController(INotifier notifier, IMediator mediador)
        {
            _notifier = notifier;
            _mediator = mediador;
        }

        [HttpGet]
        [ProducesResponseType(typeof(SuccessRequestResponseDefault<decimal>), 200)]
        [ProducesResponseType(typeof(BadRequestDefaultModel), 400)]
        [ProducesResponseType(typeof(InternalServerErrorDefaultModel), 500)]
        public async Task<IActionResult> Get(decimal valorinicial, int meses)
        {
            var request = new CalculoJurosRequest(valorinicial, meses);
            return this.GetResponse<CalculoJurosResponse>(_notifier, await _mediator.Send(request));
        }
    }
}
