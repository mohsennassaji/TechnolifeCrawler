namespace Application.TechnoLifeCrawler.PageParser
{
    public interface ITechnoLifePageParser
    {
        Task<string> Parse(string text);
    }
}
