using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.ProductScraper
{
    public interface ITechnoLifeProductScraper
    {
        Task ExtractProductInformation(Product technoLifeProduct);
    }
}
