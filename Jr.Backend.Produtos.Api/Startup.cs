using Jr.Backend.Libs.API.Abstractions;
using Jr.Backend.Libs.API.DependencyInjection;
using Jr.Backend.Libs.Framework.DependencyInjection;
using Jr.Backend.Libs.Security.Abstractions.Infrastructure.Interfaces;
using Jr.Backend.Libs.Security.DependencyInjection;
using Jr.Backend.Libs.Security.Infrastructure;
using Jr.Backend.Libs.Security.Middleware;
using Jr.Backend.Produtos.Application.DependencyInjection;
using Jr.Backend.Produtos.Infrastructure.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.Produtos.Api
{
    public class Startup
    {
        private readonly IJrApiOption jrApiOption;
        private readonly ISecurityConfiguration serSecurityConfiguration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrApiOption
            {
                Title = "Jr.Backend.Produtos.Api",
                Description = "Api de Cadastro de Produtos",
                Email = "joaocte@gmail.com",
                Uri = "https://github.com/joaocte/Jr.Backend.Produto",
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
            services.AddServiceDependencyJrApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyJrFramework();
            services.AddServiceDependencyJrSecurityApiUsingCustomValidate(() => serSecurityConfiguration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrApiSwaggerSecurity(env, () => jrApiOption);
            app.UseSecurity();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}