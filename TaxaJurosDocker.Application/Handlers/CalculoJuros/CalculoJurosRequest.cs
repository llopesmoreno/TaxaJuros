using MediatR;

namespace TaxaJurosDocker.Application.Handlers.CalculoJuros
{
    public class CalculoJurosRequest : IRequest<CalculoJurosResponse>
    {
        public CalculoJurosRequest()
        {

        }

        public CalculoJurosRequest(decimal valorInicial, int meses)
        {
            ValorInicial = valorInicial;
            Meses = meses;
        }

        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
    }
}
