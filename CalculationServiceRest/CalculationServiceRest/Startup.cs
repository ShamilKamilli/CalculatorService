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
using NLog.Config;
using NLog.Targets;
using NLog.Web;
using SoapServiceReference;
using System.IO;

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
                LoggingConfiguration conf = new LoggingConfiguration();

                #region File Logger Configuration
                var fileTarget = new FileTarget
                {
                    Layout = @"${level}(${longdate})${machinename}------${newline}
                      Exception Type:${exception:format=Type} |
                      Exception Message:${exception:format=Message} |
                      Stack Trace:${exception:format=Stack Trace} |
                      Additional Info:${message}${newline}",
                    ArchiveNumbering = ArchiveNumberingMode.Date,
                    ArchiveAboveSize= 5242880,
                    ArchiveEvery=FileArchivePeriod.Minute,
                    ArchiveDateFormat= "yyyyMMdd",
                    FileName= Path.Combine(Directory.GetCurrentDirectory(),"Logs","Exceptions", "${date:format=yyyy-MM-dd}.txt")
                };
                conf.AddTarget("exceptionlog", fileTarget);
                #endregion

                #region Database Configuration
                var databaseTarget = new DatabaseTarget()
                {
                    ConnectionString = _configuration.GetConnectionString("CalculationServiceConnection"),
                    CommandText = "insert into dbo.logs (METHOD_TYPE,INSERT_DATE,VALUE)" +
                    "values (@METHOD_TYPE,@INSERT_DATE,@VALUE)"
                };
                databaseTarget.Parameters.Add(new DatabaseParameterInfo
                {
                    Name = "@INSERT_DATE",
                    DbType = "SqlDbType.Time",
                    Layout = "${event-properties:item=INSERT_DATE}"
                });
                databaseTarget.Parameters.Add(new DatabaseParameterInfo
                {
                    Name = "@VALUE",
                    Layout = "${event-properties:item=VALUE}"
                });
                databaseTarget.Parameters.Add(new DatabaseParameterInfo
                {
                    Name = "@METHOD_TYPE",
                    DbType = "SqlDbType.Int",
                    Layout = "${event-properties:item=METHOD_TYPE}"
                });
                conf.AddTarget("database", databaseTarget);
                #endregion

                conf.AddRule(LogLevel.Error, LogLevel.Error, "exceptionlog");
                conf.AddRule(LogLevel.Info, LogLevel.Info, "database");

                return NLogBuilder.ConfigureNLog(conf).GetCurrentClassLogger();
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
