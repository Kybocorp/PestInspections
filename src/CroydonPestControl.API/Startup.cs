using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CroydonPestControl.AppServices.Interfaces;
using CroydonPestControl.AppServices;
using AutoMapper;
using CroydonPestControl.Infrastructure.Interfaces;
using CroydonPestControl.Infrastructure;
using CroydonPestControl.Core.Helpers;
using CroydonPestControl.Core;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Text;

using Serilog;
using System;

namespace CroydonPestControl.API
{
    public partial class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
                Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .WriteTo.RollingFile("../logs/log-{Date}.txt").CreateLogger();
            }

            Log.Logger = new LoggerConfiguration()
                         .MinimumLevel.Information()
                         .WriteTo.RollingFile("../logs/log-{Date}.txt").CreateLogger();

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddSingleton<IConfiguration>(Configuration);
            services.AddMvc();
            services.AddAutoMapper();

            services.AddSwaggerGen();
            services.AddScoped<IXmlHelper, XmlHelper>();

            services.AddScoped<IConfigurationsRepository, ConfigurationsRepository>();
            services.AddScoped<IInspectionRepository, InspectionRepository>();
            services.AddTransient<IInspectionAppService, InspectionAppService>();
            services.AddTransient<IAdminAppService, AdminAppService>();
            services.AddTransient<IConfigurationsAppService, ConfigurationsAppService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            try
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var ex = context.Features.Get<IExceptionHandlerFeature>();
                        if (ex != null)
                        {
                            var err = JsonConvert.SerializeObject(new Error()
                            {
                                Stacktrace = ex.Error.StackTrace,
                                Message = ex.Error.Message
                            });
                            await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
                        }
                    });
                });

                if (env.IsDevelopment())
                {
                    loggerFactory.AddDebug(LogLevel.Information).AddSerilog();
                }
                else
                {
                    loggerFactory.AddDebug(LogLevel.Error).AddSerilog();
                }

                ConfigureAuth(app);
                app.UseApplicationInsightsRequestTelemetry();
                app.UseApplicationInsightsExceptionTelemetry();
                app.UseMvc();
                app.UseSwagger();
                app.UseSwaggerUi();
            }
            catch(Exception ex)
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(
                    async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";
                        var err = JsonConvert.SerializeObject(new Error()
                        {
                            Stacktrace = ex.StackTrace,
                            Message = ex.Message
                        });
                        await context.Response.Body.WriteAsync(Encoding.ASCII.GetBytes(err), 0, err.Length).ConfigureAwait(false);
                    });
                });
            }  
        }
    }
}
