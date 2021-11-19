using GreenPipes;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jr.Backend.Produtos.WorkerService.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyWorkerService(this IServiceCollection services, IConfiguration configuration)
        {
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
                     });
                     cfg.ReceiveEndpoint("FornecedorAtualizadoEvent", ep =>
                     {
                         ep.PrefetchCount = 10;
                         ep.UseMessageRetry(r => r.Interval(2, 100));
                     });
                 }));
            });
            services.AddMassTransitHostedService();
        }
    }
}