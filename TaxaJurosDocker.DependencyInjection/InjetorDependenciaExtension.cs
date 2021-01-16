using MediatR;
using FluentValidation;
using TaxaJurosDocker.Application;
using TaxaJurosDocker.Application.Util;
using Microsoft.Extensions.Configuration;
using TaxaJurosDocker.Application.Services;
using TaxaJurosDocker.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using TaxaJurosDocker.Application.ConfigurationApp;
using TaxaJurosDocker.Application.Handlers.CalculoJuros;

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
            IncluirVariaveisDeAmbiente(services, configuration);
            IncluirHttpClientServices(services);            
        }

        private static void IncluirHttpClientServices(IServiceCollection services)
        {
            services.AddScoped<ITaxaJurosHttpService, TaxaJurosHttpService>();
        }

        private static void IncluirVariaveisDeAmbiente(IServiceCollection services, IConfigurationRoot configuration)
        {
            var urlObterTaxaJuros = configuration.GetSection("IntegracaoEndpointsUrl:ObterTaxaJuros").Value;
            services.AddScoped(i => new EnvironmentConfig
            {
                UrlObterTaxaJuros = urlObterTaxaJuros
            });
        }

        private static void RegistrarValidadores(IServiceCollection services)
        {
            services.AddScoped<IValidator<CalculoJurosRequest>, CalculoJurosRequestValidator>();            
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
