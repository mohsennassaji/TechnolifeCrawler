using Application.Services;
using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public class TechnoLifePageParser : IProductListParser
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;

        public TechnoLifePageParser(IDatabaseService databaseService, ILogManagmentService log)
        {
            _databaseService = databaseService;
            _log = log;
        }

        public async Task<List<Product>> Parse(string page)
        {
            //parse file
            //get products
            //save products
            //get next links
            throw new NotImplementedException();
        }

        public async Task<int> GetMaximumActivePageNumber(string page)
        {
            throw new NotImplementedException();
        }
    }
}
