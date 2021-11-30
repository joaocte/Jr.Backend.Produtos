using GreenPipes;
using Jror.Backend.Produtos.Application.DependencyInjection;
using Jror.Backend.Produtos.Application.UseCase.AtualizarFornecedor;
using Jror.Backend.Produtos.Application.UseCase.CadastrarFornecedor;
using Jror.Backend.Produtos.Infrastructure.DependencyInjection;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jror.Backend.Produtos.WorkerService.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyWorkerService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyApplication();
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
                 {
                     cfg.Host(new Uri(configuration["RabbitSetting:UriBase"]), h =>
                     {
                         h.Username(configuration["RabbitSetting:User"]);
                         h.Password(configuration["RabbitSetting:Password"]);
                     });

                     cfg.ReceiveEndpoint("FornecedorCadastradoEvent", ep =>
                     {
                         ep.PrefetchCount = 10;
                         ep.UseMessageRetry(r => r.Interval(2, 100));
                         ep.Consumer<CadastrarFornecedorUseCaseValidation>(provider);
                     });
                     cfg.ReceiveEndpoint("FornecedorAtualizadoEvent", ep =>
                     {
                         ep.PrefetchCount = 10;
                         ep.UseMessageRetry(r => r.Interval(2, 100));
                         ep.Consumer<AtualizarFornecedorUseCaseValidation>(provider);
                     });
                 }));
                x.AddConsumer<CadastrarFornecedorUseCaseValidation>();
                x.AddConsumer<AtualizarFornecedorUseCaseValidation>();
            });

            services.AddMassTransitHostedService();
        }
    }
}