using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public interface IProductListParser
    {
        List<Product> Parse(string page);
        int GetMaximumActivePageNumber(string page);
    }
}
