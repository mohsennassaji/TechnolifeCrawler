using Application.Services;
using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.ProductScraper
{
    public class TechnoLifeProductScraper : IProductParser
    {
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;

        public TechnoLifeProductScraper(IDatabaseService databaseService, ILogManagmentService log)
        {
            _databaseService = databaseService;
            _log = log;
        }

        public async Task SaveProductImages(Product technoLifeProduct)
        {
            //get link of product
            //get information of link
            //pars information
            //save information
            throw new NotImplementedException();
        }

        public async Task SaveProductSpecification(Product technoLifeProduct)
        {
            //get link of product
            //get information of link
            //pars information
            //save information
            throw new NotImplementedException();
        }
    }
}
