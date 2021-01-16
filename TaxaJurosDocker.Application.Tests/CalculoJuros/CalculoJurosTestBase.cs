using Moq;
using Xunit;
using System;
using MediatR;
using FluentValidation;
using System.Threading.Tasks;
using TaxaJurosDocker.Application.Util;
using TaxaJurosDocker.Application.Services;
using TaxaJurosDocker.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using TaxaJurosDocker.Application.Handlers.CalculoJuros;

namespace TaxaJurosDocker.Application.Tests.CalculoJuros
{
    public abstract class CalculoJurosTestBase
    {
        private readonly IServiceProvider services;

        public CalculoJurosTestBase()
        {
            services = BuildService();
            Mediator = services.GetService<IMediator>();
        }

        private IServiceProvider BuildService()
        {
            TaxaJurosHttpService = new Mock<ITaxaJurosHttpService>();

            var serviceCollection =
                new ServiceCollection()
                .AddMediatR(typeof(IMarcMediator))
                .AddSingleton(TaxaJurosHttpService.Object)
                .AddScoped<IValidator<CalculoJurosRequest>, CalculoJurosRequestValidator>()
                .AddScoped<INotifier, Notifier>();                

            return serviceCollection.BuildServiceProvider();            
        }

        internal void PreparaHttpServices()
        {
            TaxaJurosHttpService.Setup(s => s.GetTaxa()).ReturnsAsync(0.01);
        }

        protected void AssegurarNotificacoes(CalculoJurosResponse result, string message)
        {
            Assert.Null(result);
            var notifier = GetNotifier();
            Assert.True(notifier.AnyNotification());
            Assert.Contains(message, notifier.GetMessageNotifications());
        }

        protected IMediator Mediator { get; private set; }

        protected Mock<ITaxaJurosHttpService> TaxaJurosHttpService { get; private set; }
        protected INotifier GetNotifier() => services.GetService<INotifier>();        

        public abstract Task Calcular_Juros_Com_Sucesso();
        public abstract Task Calcular_Juros_Com_Erro_Parametro_ValorInicial_Invalido();
        public abstract Task Calcular_Juros_Com_Erro_Parametro_Meses_Invalido();
    }
}
