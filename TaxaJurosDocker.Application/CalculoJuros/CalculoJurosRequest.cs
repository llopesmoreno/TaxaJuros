using MediatR;

namespace TaxaJurosDocker.Application.CalculoJuros
{
    public class CalculoJurosRequest : IRequest<CalculoJurosResponse>
    {
        public CalculoJurosRequest()
        {

        }

        public CalculoJurosRequest(decimal valor, int meses)
        {
            Valor = valor;
            Meses = meses;
        }

        public decimal Valor { get; set; }
        public int Meses { get; set; }
    }
}
