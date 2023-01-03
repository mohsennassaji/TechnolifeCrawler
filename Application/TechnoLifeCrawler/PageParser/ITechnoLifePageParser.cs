namespace Application.TechnoLifeCrawler.PageParser
{
    public interface ITechnoLifePageParser
    {
        Task<List<string>> Parse(string page);
    }
}
