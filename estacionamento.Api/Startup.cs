using AutoMapper;
using estacionamento.Application;
using estacionamento.Application.Dtos;
using estacionamento.Application.Interfaces;
using estacionamento.Domain.Core.Interfaces.Repositories;
using estacionamento.Domain.Core.Interfaces.Services;
using estacionamento.Domain.Entitys;
using estacionamento.Domain.Services;
using estacionamento.Infrastructure.Data;
using estacionamento.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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
            services.AddDbContext<SqlContext>(options => options.UseInMemoryDatabase(databaseName: "estacionamento").EnableSensitiveDataLogging());

            services.AddScoped<SqlContext>();

            services.AddScoped<IApplicationServiceEstabelecimento, ApplicationServiceEstabelecimento>();
            services.AddScoped<IApplicationServiceVeiculo, ApplicationServiceVeiculo>();
            services.AddScoped<IApplicationServiceRelatorio, ApplicationServiceRelatorio>();

            services.AddScoped<IServiceEstabelecimento, ServiceEstabelecimento>();
            services.AddScoped<IServiceVeiculo, ServiceVeiculo>();

            services.AddScoped<IRepositoryEstabelecimento, RepositoryEstabelecimento>();
            services.AddScoped<IRepositoryVeiculo, RepositoryVeiculo>();

            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true;
            });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EstabelecimentoDto, Estabelecimento>();
                cfg.CreateMap<Estabelecimento, EstabelecimentoDto>();

                cfg.CreateMap<VeiculoDto, Veiculo>();
                cfg.CreateMap<Veiculo, VeiculoDto>();
            });

            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services
                .AddMvcCore()
                .AddXmlSerializerFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(opt =>
             {
                 opt.SwaggerDoc("v1", new OpenApiInfo
                 {
                     Title = "ESTACIONAMENTO",
                     Version = "v1",
                     Description = "Management parking system",
                     Contact = new OpenApiContact
                     {
                         Name = "Thauê ALfredo F. Lima",
                         Email = "thaue159@gmail.com",
                         Url = new Uri("https://www.linkedin.com/in/thaue-alfredo-ferreira-lima-62504619b/")
                     },
                     License = new OpenApiLicense
                     {
                         Name = "MIT",
                         Url = new Uri("https://github.com/thauealfredo/estacionamento/blob/master/LICENSE")
                     }
                 });

                 var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                 var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                 opt.IncludeXmlComments(xmlPath);

                 opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                 {
                     Description = @"JWT Authorization header using the Bearer scheme. Example: 'Bearer 12345abcdef'",
                     Name = "Authorization",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer"
                 });

                 opt.AddSecurityRequirement(new OpenApiSecurityRequirement()
                  {
                    {
                      new OpenApiSecurityScheme
                      {
                        Reference = new OpenApiReference
                          {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                          },
                          Scheme = "oauth2",
                          Name = "Bearer",
                          In = ParameterLocation.Header,
                        },
                        new List<string>()
                      }
                 });
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

            app.UseSwaggerUI(opt =>
            {
                opt.DefaultModelsExpandDepth(-1);
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "ESTACIONAMENTO");
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