using Application.Services;
using Application.TechnoLifeCrawler.PageParser;
using Application.TechnoLifeCrawler.ProductScraper;

namespace Application.Crawler
{
    public class Crawler : ICrawler
    {
        private readonly ITechnoLifePageParser _technoLifePageParser;
        private readonly ITechnoLifeProductScraper _technoLifeProductScraper;
        private readonly ILogManagmentService _log;
        private readonly Queue<string> _crawlQueue;

        public Crawler(ITechnoLifePageParser technoLifePageParser, ITechnoLifeProductScraper technoLifeProductScraper, ILogManagmentService log)
        {
            _technoLifePageParser = technoLifePageParser;
            _technoLifeProductScraper = technoLifeProductScraper;
            _log = log;
            _crawlQueue = new Queue<string>();
        }
        public async Task Crawl(string url)
        {
            _crawlQueue.Enqueue(url);
            //crawl link and get page
            //parse page
            //get products
            //save product information
            //scrap products
            //save scrapted data
            throw new NotImplementedException();
        }
    }
}
