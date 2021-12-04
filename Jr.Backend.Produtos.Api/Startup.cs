using Jr.Backend.Produtos.Application.DependencyInjection;
using Jr.Backend.Produtos.Infrastructure.DependencyInjection;
using Jror.Backend.Libs.Api.DependencyInjection;
using Jror.Backend.Libs.API.Abstractions;
using Jror.Backend.Libs.API.Abstractions.Interface;
using Jror.Backend.Libs.Framework.DependencyInjection;
using Jror.Backend.Libs.Security.Abstractions.Infrastructure.Interfaces;
using Jror.Backend.Libs.Security.DependencyInjection;
using Jror.Backend.Libs.Security.Infrastructure;
using Jror.Backend.Libs.Security.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.Produtos.Api
{
    public class Startup
    {
        private readonly IJrorApiOption jrApiOption;
        private readonly ISecurityConfiguration serSecurityConfiguration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrorApiOption
            {
                Title = "Jror.Backend.Produtos.Api",
                Description = "Api de Cadastro de Produtos",
                Email = "joaocte@gmail.com",
                Uri = "https://github.com/joaocte/Jror.Backend.Produto",
            };
            serSecurityConfiguration =
                new SecurityConfiguration("mongodb://localhost:27017/?authSource=admin", "JrTenant");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrorApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyJrorFramework();
            services.AddServiceDependencyJrorSecurityApiUsingCustomValidate(() => serSecurityConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrorApiSwaggerSecurity(env, () => jrApiOption);
            app.UseSecurity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}