using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projeto.Application.Contracts;
using Projeto.Application.Services;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Services;
using Projeto.Infra.Data.Contexts;
using Projeto.Infra.Data.Repositories;

namespace Projeto.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //configura��o da documenta��o do Swagger
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API para Inclus�o de Benefici�rios",
                        Version = "v1",
                        Description = "Projeto desenvolvido em NET CORE 3.1 API usando o padr�o DDD (Domain Driven Design)",
                        Contact = new OpenApiContact
                        {
                            Name = "Felipe Sampaio - Pipo Sa�de",
                            Url = new Uri("https://www.linkedin.com/in/felipe-sampaio-carvalho-147541192/"),
                            Email = "felipe.sampaio91@gmail.com"
                        }
                    });
            });

            services.AddDbContext<DataContext>(d => d.UseSqlServer(Configuration.GetConnectionString("PipoSaude")));

            services.AddTransient<IOperadoraApplicationService, OperadoraApplicationService>();
            services.AddTransient<IClienteApplicationService, ClienteApplicationService>();
            services.AddTransient<IClienteBeneficioApplicationService, ClienteBeneficioApplicationService>();
            services.AddTransient<IBeneficioApplicationService, BeneficioApplicationService>();
            services.AddTransient<IFuncionarioApplicationService, FuncionarioApplicationService>();

            services.AddTransient<IOperadoraDomainService, OperadoraDomainService>();
            services.AddTransient<IClienteDomainService, ClienteDomainService>();
            services.AddTransient<IClienteBeneficioDomainService, ClienteBeneficioDomainService>();
            services.AddTransient<IBeneficioDomainService, BeneficioDomainService>();
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();

            services.AddTransient<IOperadoraRepository, OperadoraRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteBeneficioRepository, ClienteBeneficioRepository>();
            services.AddTransient<IBeneficioRepository, BeneficioRepository>();
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //configura��o do swagger
            app.UseSwagger();
            app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "Projeto Pipo"); });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
