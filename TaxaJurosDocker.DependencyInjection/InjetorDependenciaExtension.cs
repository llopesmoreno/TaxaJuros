using MediatR;
using TaxaJurosDocker.Application;
using TaxaJurosDocker.Application.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TaxaJurosDocker.DependencyInjection
{
    public static class InjetorDependenciaExtension
    {
        public static void RegisterServices(this IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddScoped<INotifier, Notifier>();
            services.AddHttpContextAccessor();
            services.AddMediatR(typeof(IMarcMediator));

            RegistrarValidadores(services);
            IncluirHttpClientSingleton(services);
        }

        private static void RegistrarValidadores(IServiceCollection services)
        {
//            services.AddScoped<IValidator<Usuario>, UsuarioValidador>();            
        }

        private static void IncluirHttpClientSingleton(IServiceCollection services)
        {
            var clientHandler = new System.Net.Http.HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            var httpClient = new System.Net.Http.HttpClient(clientHandler);

            services.AddSingleton(httpClient);
        }
    }
}
