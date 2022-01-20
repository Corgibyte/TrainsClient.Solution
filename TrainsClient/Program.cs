using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TrainsClient.Models;

namespace TrainsClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            Route.GetRoutes(1, 5);

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}