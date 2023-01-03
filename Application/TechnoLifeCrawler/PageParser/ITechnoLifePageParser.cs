using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public interface ITechnoLifePageParser
    {
        Task<List<Product>> Parse(string page);
    }
}
