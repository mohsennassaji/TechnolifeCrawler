using Domain.TechnoLifeProducts;

namespace Application.TechnoLifeCrawler.ProductScraper
{
    public interface IProductParser
    {
        Task SaveProductImages(Product technoLifeProduct);
        Task SaveProductSpecification(Product technoLifeProduct);
    }
}
