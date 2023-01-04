using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.PageParser
{
    public interface IProductListParser
    {
        List<Product> GetProducts(string page);
        int GetMaximumActivePageNumber(string page);
    }
}
