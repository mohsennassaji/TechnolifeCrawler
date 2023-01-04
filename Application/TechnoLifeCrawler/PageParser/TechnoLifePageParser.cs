using Application.Services;
using Domain.TechnoLifeProducts;
using HtmlAgilityPack;

namespace Application.TechnoLifeCrawler.PageParser
{
    public class TechnoLifePageParser : IProductListParser
    {
        private readonly ILogManagmentService _log;

        public TechnoLifePageParser(ILogManagmentService log)
        {
            _log = log;
        }

        public List<Product> Parse(string page)
        {
            //parse file
            //get products
            //save products
            //get next links
            throw new NotImplementedException();
        }

        public int GetMaximumActivePageNumber(string page)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);

            var nodes = htmlDocument.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("active-pagenavigation")).Select(n => n.InnerText).ToList();
            
            return int.Parse(nodes.Max()); 
        }
    }
}
