using Application.Crawler;
using Application.TechnoLifeCrawler.PageParser;
using Application.TechnoLifeCrawler.ProductScraper;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ICrawler, Crawler.Crawler>();
            services.AddTransient<ITechnoLifeProductScraper, TechnoLifeProductScraper>();
            services.AddTransient<ITechnoLifePageParser, TechnoLifePageParser>();

            return services;
        }
    }
}
