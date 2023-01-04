using Application.Services;
using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public class TechnoLifePageParser : IProductListParser
    {
        private readonly ILogManagmentService _log;

        public TechnoLifePageParser(ILogManagmentService log)
        {
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
