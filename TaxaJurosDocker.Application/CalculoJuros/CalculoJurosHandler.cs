using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaxaJurosDocker.Application.Util;

namespace TaxaJurosDocker.Application.CalculoJuros
{
    public class CalculoJurosHandler : IRequestHandler<CalculoJurosRequest, CalculoJurosResponse>
    {
        private readonly INotifier notifier;

        public CalculoJurosHandler(INotifier notifier)
        {
            this.notifier = notifier;
        }

        public async Task<CalculoJurosResponse> Handle(CalculoJurosRequest request, CancellationToken cancellationToken)
        {
            return new CalculoJurosResponse
            {
                Result = 123m
            };
        }
    }
}
