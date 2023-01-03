using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public interface ITechnoLifePageParser
    {
        Task<List<TechnoLifeProduct>> Parse(string page);
    }
}
