using Xunit;
using System.Threading.Tasks;
using TaxaJurosDocker.Application.Handlers.CalculoJuros;

namespace TaxaJurosDocker.Application.Tests.CalculoJuros
{
    public class CalculoJurosHandlerTests : CalculoJurosTestBase
    {
        [Fact]
        public override async Task Calcular_Juros_Com_Erro_Parametro_Meses_Invalido()
        {
            PreparaHttpServices();
            var request = new CalculoJurosRequest(100, 0);
            var result = await Mediator.Send(request);
            AssegurarNotificacoes(result, "Parâmetro inválido [meses]");            
        }

        [Fact]
        public override async Task Calcular_Juros_Com_Erro_Parametro_ValorInicial_Invalido()
        {
            PreparaHttpServices();            
            var request = new CalculoJurosRequest(0, 5);
            var result = await Mediator.Send(request);
            AssegurarNotificacoes(result, "Parâmetro inválido [valorInicial]");
        }

        [Fact]
        public override async Task Calcular_Juros_Com_Sucesso()
        {
            PreparaHttpServices();
            var request = new CalculoJurosRequest(100, 5);
            var result = await Mediator.Send(request);

            Assert.NotNull(result);
            Assert.True(result.Result == 105.10m);
        }
    }
}
