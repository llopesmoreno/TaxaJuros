namespace TaxaJurosDocker.Application.Handlers.CalculoJuros
{
    public class CalculoJurosResponse
    {
        public CalculoJurosResponse()
        {

        }

        public CalculoJurosResponse(decimal result)
        {
            Result = result;
        }

        public decimal Result { get; set; }
    }
}
