using System.Threading.Tasks;

namespace TaxaJurosDocker.Application.Services
{
    public interface ITaxaJurosHttpService
    {
        Task<double> GetTaxa();
    }
}
