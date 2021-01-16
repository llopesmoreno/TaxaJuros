using System;
using MediatR;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;
using TaxaJurosDocker.Application.Util;
using TaxaJurosDocker.Application.Services;

namespace TaxaJurosDocker.Application.Handlers.CalculoJuros
{
    public class CalculoJurosHandler : IRequestHandler<CalculoJurosRequest, CalculoJurosResponse>
    {
        private readonly INotifier _notifier;
        private readonly IValidator<CalculoJurosRequest> _validator;
        private readonly ITaxaJurosHttpService _taxaJurosService;

        public CalculoJurosHandler(INotifier notifier, IValidator<CalculoJurosRequest> validator, ITaxaJurosHttpService taxaJurosService)
        {
            _notifier = notifier;
            _validator = validator;
            _taxaJurosService = taxaJurosService;
        }

        public async Task<CalculoJurosResponse> Handle(CalculoJurosRequest request, CancellationToken cancellationToken)
        {
            if (request.InvalidObject(_validator, _notifier))
                return null;

            var taxa = await _taxaJurosService.GetTaxa();

            var result = Calcular(request.ValorInicial, request.Meses, taxa);

            return new CalculoJurosResponse(result);
        }

        private decimal Calcular(decimal valorInicial, int meses, double taxa)
        {   
            var calculoTaxacaoMensal = Math.Pow(1 + taxa, meses);
            var calculo = calculoTaxacaoMensal * (double)valorInicial;            
            var retorno = (decimal)Math.Truncate(100 * calculo) / 100;
            return retorno;
        }
    }
}
