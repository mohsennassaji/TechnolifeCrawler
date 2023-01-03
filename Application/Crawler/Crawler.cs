using Application.TechnoLifeCrawler.PageParser;
using Application.TechnoLifeCrawler.ProductScraper;

namespace Application.Crawler
{
    public class Crawler : ICrawler
    {
        private readonly ITechnoLifePageParser _technoLifePageParser;
        private readonly ITechnoLifeProductScraper _technoLifeProductScraper;

        public Crawler(ITechnoLifePageParser technoLifePageParser, ITechnoLifeProductScraper technoLifeProductScraper)
        {
            _technoLifePageParser = technoLifePageParser;
            _technoLifeProductScraper = technoLifeProductScraper;
        }
        public Task Crawl(string url)
        {
            throw new NotImplementedException();
        }
    }
}
