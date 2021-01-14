using System;
using System.IO;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using TaxaJurosDocker.BaseApi.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TaxaJurosDocker.BaseApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using TaxaJurosDocker.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace TaxaJurosDocker.Api
{
    public class Startup
    {
        public Startup() => Configuration = BuildConfiguration();

        public IConfigurationRoot BuildConfiguration()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddEnvironmentVariables()
           .AddJsonFile("appsettings.json", false)
           .AddJsonFile($"appsettings.{env}.json", true);

            return config.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Converters = new List<JsonConverter> { new DecimalFormatConverter() }
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaxaJurosDocker Api", Version = "v1" });
                c.IncludeXmlComments("TaxaJurosDocker.Api.xml");
            });

            services.RegisterServices(Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("../swagger/v1/swagger.json", "TaxaJurosDocker Api V1");
                });
            }

            ImplementEvents(app, env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ImplementEvents(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(handler =>
            {
                handler.Run(async context =>
                {
                    var exception = context.Features.Get<IExceptionHandlerFeature>();

                    if (exception != null)
                    {
                        //se desejar gravar um log da exception, pode configurar o serilog e gravar como abaixo
                        //logger.LogError(500, "mensagem: {mesagem} trace: {result}, protocolo: {protocolo}", exception.Error.Message, exception.Error.StackTrace, erroServidorRespostaPadrao.Protocolo);
                    }

                    var erroServidorRespostaPadrao = new InternalServerErrorDefaultModel();
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json; charset=utf-8";

                    var jsonStringResposta = JsonConvert.SerializeObject(erroServidorRespostaPadrao);

                    await context.Response.WriteAsync(jsonStringResposta);
                });
            });
        }
    }

    
}
