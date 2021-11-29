using AutoMapper;
using Jr.Backend.Produtos.Application.AutoMapper;
using Jr.Backend.Produtos.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Produtos.Application.UseCase.CadastrarFornecedor;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Jr.Backend.Produtos.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddServiceDependencyApplication();
            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                    {
                        var uri = configuration["RabbitSetting:UriBase"];
                        var user = configuration["RabbitSetting:User"];
                        var password = configuration["RabbitSetting:Password"];
                        config.Host(new Uri(uri), h =>
                        {
                            h.Username(user);
                            h.Password(password);
                        });
                    }
                ));
            });

            services.AddMassTransitHostedService();
        }

        public static void AddServiceDependencyApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<ICadastrarFornecedorUseCase, CadastrarFornecedorUseCase>();
            services.Decorate<ICadastrarFornecedorUseCase, CadastrarFornecedorUseCaseValidation>();
            services.AddScoped<IAtualizarFornecedorUseCase, AtualizarFornecedorUseCase>();
            services.Decorate<IAtualizarFornecedorUseCase, AtualizarFornecedorUseCaseValidation>();
        }
    }
}