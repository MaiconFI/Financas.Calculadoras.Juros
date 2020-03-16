using AutoMapper;
using Financas.Calculadoras.Juros.Api.Controllers.ApiV1;
using Financas.Calculadoras.Juros.Clients.IoC;
using Financas.Calculadoras.Juros.Queries.CalculoDeJuros;
using Financas.Calculadoras.Juros.Queries.Mappers;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Polly;
using Polly.Extensions.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace Financas.Calculadoras.Juros.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseMvc()
                .UseApiVersioning();

            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach (var description in provider.ApiVersionDescriptions)
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    }
                });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc(m => { m.EnableEndpointRouting = false; })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddApiVersioning(s =>
            {
                s.DefaultApiVersion = new ApiVersion(1, 0);
                s.ReportApiVersions = true;
                s.AssumeDefaultVersionWhenUnspecified = true;

                s.Conventions.Controller<CalculadoraDeJurosV1Controller>().HasApiVersion(new ApiVersion(1, 0));
            });

            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");

            services.AddSwaggerGen(options =>
            {
                var provider = services.BuildServiceProvider()
                               .GetRequiredService<IApiVersionDescriptionProvider>();

                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerDoc(
                        description.GroupName,
                        new OpenApiInfo
                        {
                            Title = $"Calculadora de Juros API {description.ApiVersion}",
                            Version = description.ApiVersion.ToString(),
                        });
                }
            });

            services.AddHttpClient("TaxaDeJurosV1", c => { c.BaseAddress = new Uri(_configuration["UrlDaApiDeTaxasDeJurosV1"]); })
                .AddPolicyHandler(GetRetryPolicy());

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CalculadoraDeJurosQueriesProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            IoCClients.Register(services);
            services.AddMediatR(typeof(CalcularJurosQueryHandler).GetTypeInfo().Assembly);
        }

        private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy() =>
            HttpPolicyExtensions.HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(3, retryAttempt)));
    }
}