using estacionamento.Application;
using estacionamento.Application.Interfaces;
using estacionamento.Application.Interfaces.Mappers;
using estacionamento.Application.Mappers;
using estacionamento.Domain.Core.Interfaces.Repositorys;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using estacionamento.Domain.Services;
using estacionamento.Infrastructure.Data;
using estacionamento.Infrastructure.Data.Repositorys;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace estacionamento.Api
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
            var host = Configuration["DBHOST"] ?? "localhost";
            var port = Configuration["DBPORT"] ?? "3306";
            var user = Configuration["DBUSER"] ?? "root";
            var password = Configuration["DBPASSWORD"] ?? "usbw";


            services.AddDbContext<SqlContext>(options => options.UseInMemoryDatabase(databaseName: "estacionamento"));

            //services.AddDbContext<SqlContext>(options =>
            //      options.UseMySql($"server={host};userid={user};pwd={password};"
            //          + $"port={port};database=DDD"));

            services.AddScoped<IApplicationServiceEstabelecimento, ApplicationServiceEstabelecimento>();
            services.AddScoped<IApplicationServiceVeiculo, ApplicationServiceVeiculo>();

            services.AddScoped<IServiceEstabelecimento<Estabelecimento>, ServiceEstabelecimento<Estabelecimento>>();
            services.AddScoped<IServiceVeiculo<Veiculo>, ServiceVeiculo<Veiculo>>();

            services.AddScoped<IRepositoryEstabelecimento<Estabelecimento>, RepositoryEstabelecimento<Estabelecimento>>();
            services.AddScoped<IRepositoryVeiculo<Veiculo>, RepositoryVeiculo<Veiculo>>();

            services.AddScoped<IMapperEstabelecimento, MapperEstabelecimento>();
            services.AddScoped<IMapperVeiculo, MapperVeiculo>();

            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ESTACIONAMENTO", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ESTACIONAMENTO");
            });

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