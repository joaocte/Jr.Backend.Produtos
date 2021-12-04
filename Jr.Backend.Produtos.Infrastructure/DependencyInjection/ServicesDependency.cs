using Jr.Backend.Produtos.Infrastructure.Entity;
using Jr.Backend.Produtos.Infrastructure.Interfaces;
using Jr.Backend.Produtos.Infrastructure.Repository;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Produtos.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrorInfrastructureMongoDb(ConnectionType.DirectConnection);

            services.AddScoped<IFornecedorRepository>(p =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new FornecedorRepository(mongoContext, nameof(Fornecedor));
            });
        }
    }
}