using CalculationServiceRest.Core.Interfaces;
using CalculationServiceRest.Core.ServiceImplementation;
using CalculationServiceRest.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using NLog.Web;
using SoapServiceReference;

namespace CalculationServiceRest
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;

            GlobalDiagnosticsContext.Set("connectionString",_configuration.GetConnectionString("CalculationServiceConnection"));
        }

       
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CalculationDbContext>(opt =>
            {
                opt.UseSqlServer(_configuration.GetConnectionString("CalculationServiceConnection"));
            });

            services.AddSingleton<CalculatorSoap>(new CalculatorSoapClient(CalculatorSoapClient.EndpointConfiguration.CalculatorSoap));

            services.AddSingleton<ICalculatorService, CalculatorServiceImplementation>();

            services.AddScoped<ILogger>(x =>
            {
                return NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            });

            services.AddScoped<ILoggerDependency, LoggerDependency>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
