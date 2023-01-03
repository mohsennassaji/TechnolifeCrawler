using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public interface IProductListParser
    {
        Task<List<Product>> Parse(string page);
        Task<int> GetMaximumActivePageNumber(string page);
    }
}
