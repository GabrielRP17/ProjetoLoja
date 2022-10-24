using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProjetoLoja.Interfaces;
using ProjetoLoja.Models;
using ProjetoLoja.Repositorios;
using ProjetoLoja.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoLoja
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
            services.AddScoped<IRepositorioCartao, RepositorioCartao>();
            services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            services.AddScoped<IRepositorioCompra, RepositorioCompra>();
            services.AddScoped<IRepositorioEstoqueLoja, RepositorioEstoqueLoja>();
            services.AddScoped<IRepositorioFornecedor, RepositorioFornecedor>();
            services.AddScoped<IRepositorioHistoricoCompra, RepositorioHistoricoCompra>();
            services.AddScoped<IRepositorioLoja, RepositorioLoja>();
            services.AddScoped<IRepositorioProdutoLoja, RepositorioProdutoLoja>();
            services.AddScoped<IRepositorioProdutoFornecedor, RepositorioProdutoFornecedor>();
            services.AddScoped<IRepositorioEstoqueFornecedor, RepositorioEstoqueFornecedor>();
            services.AddScoped<IRepositorioFornecedorLoja, RepositorioFornecedorLoja>();

            services.AddScoped<IServiceCartao, ServiceCartao>();
            services.AddScoped<IServiceEstoqueFornecedor, ServiceEstoqueFornecedor>();
            services.AddScoped<IServiceCliente, ServiceCliente>();
            services.AddScoped<IServiceCompra, ServiceCompra>();
            services.AddScoped<IServiceEstoqueLoja, ServiceEstoqueLoja>();
            services.AddScoped<IServiceFornecedor, ServiceFornecedor>();
            services.AddScoped<IServiceHistoricoCompra, ServiceHistoricoCompra>();
            services.AddScoped<IServiceFornecedorLoja, ServiceFornecedorLoja>();
            services.AddScoped<IServiceLoja, ServiceLoja>();
            services.AddScoped<IServiceProdutoLoja, ServiceProdutoLoja>();
            services.AddScoped<IServiceProdutoFornecedor, ServiceProdutoFornecedor>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoLoja", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoLoja v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
