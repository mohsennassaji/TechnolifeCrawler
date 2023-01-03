using Application.Services;

namespace Application.TechnoLifeCrawler.ProductScraper
{
    public class TechnoLifeProductScraper : ITechnoLifeProductScraper
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;

        public TechnoLifeProductScraper(IDatabaseService databaseService, ILogManagmentService log)
        {
            _databaseService = databaseService;
            _log = log;
        }

        public Task<string> ExtractProductInformation(string url)
        {
            //get link of product
            //get information of link
            //pars information
            //save information
            throw new NotImplementedException();
        }
    }
}
