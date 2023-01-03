namespace Application.TechnoLifeCrawler.ProductScraper
{
    public interface ITechnoLifeProductScraper
    {
        Task<string> ExtractProductInformation(string url);
    }
}
