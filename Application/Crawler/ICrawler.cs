namespace Application.Crawler
{
    public interface ICrawler
    {
        Task Crawl(string url, CancellationToken cancellationToken);
    }
}
