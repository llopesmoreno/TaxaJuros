using FluentValidation;
using TaxaJurosDocker.Application.Handlers.CalculoJuros;

namespace TaxaJurosDocker.Application.Validators
{
    public class CalculoJurosRequestValidator : AbstractValidator<CalculoJurosRequest>
    {
        public CalculoJurosRequestValidator()
        {
            RuleFor(x => x.Meses)
                .GreaterThan(0)
                .WithMessage("Parâmetro inválido [meses]");
            RuleFor(x => x.ValorInicial)
                .GreaterThan(0)
                .WithMessage("Parâmetro inválido [valorInicial]");
        }
    }
}