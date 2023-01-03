using Application;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Crawler
{
    public class Program
    {
        public async static Task Main()
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddInfrastructure(context.Configuration);
                    services.AddApplication();
                }).Build();

            var svc = ActivatorUtilities.CreateInstance<Application.Crawler.Crawler>(host.Services);
            await svc.Crawl(string.Empty);
        }

        static void BuildConfig(IConfigurationBuilder builder)
        {
            builder.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
        
    }
}