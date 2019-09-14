using System;
using System.Linq;
using CalculationServiceRest.Core;
using CalculationServiceRest.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace CalculationServiceRest
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var webHost = CreateWebHostBuilder(args).Build();

            using (var scope=webHost.Services.CreateScope())
            {
                using (var db=scope.ServiceProvider.GetRequiredService<CalculationDbContext>())
                {
                    foreach (var item in Constants.MethodTypes)
                    {
                        if(db.MethodTypes.FirstOrDefault(m=>m.Id==item.Value)==null)
                        {
                            db.MethodTypes.Add(new Models.MethodType
                            {
                                Id = item.Value,
                                InsertDate = DateTime.Now.TimeOfDay
                            });

                           db.SaveChanges();
                        }
                    }
                }
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
            .ConfigureLogging(logging =>
            {
                logging.ClearProviders();
                logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            })
            .UseNLog();
    }
}
