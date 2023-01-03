using Application.Services;
using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public class TechnoLifePageParser : ITechnoLifePageParser
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;

        public TechnoLifePageParser(IDatabaseService databaseService, ILogManagmentService log)
        {
            _databaseService = databaseService;
            _log = log;
        }

        public async Task<List<TechnoLifeProduct>> Parse(string page)
        {
            //parse file
            //get products
            //save products
            //get next links
            throw new NotImplementedException();
        }
    }
}
