using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TaxaJurosDocker.Application.ConfigurationApp;

namespace TaxaJurosDocker.Application.Services
{
    public class TaxaJurosHttpService : ITaxaJurosHttpService
    {
        private readonly EnvironmentConfig _environmentConfig;
        private readonly HttpClient _httpClient;

        public TaxaJurosHttpService(EnvironmentConfig environmentConfig, HttpClient httpClient)
        {
            _environmentConfig = environmentConfig;
            _httpClient = httpClient;
        }

        public async Task<double> GetTaxa()
        {  
            var response = await _httpClient.GetAsync(_environmentConfig.UrlObterTaxaJuros);

            var resultJson = await response.Content.ReadAsStringAsync();

            var retorno = JsonSerializer.Deserialize<double>(resultJson);
            
            return retorno;
        }
    }
}
