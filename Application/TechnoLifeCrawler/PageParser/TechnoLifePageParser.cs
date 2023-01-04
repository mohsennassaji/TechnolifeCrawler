using Application.Services;
using Domain.Enums;
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

        public List<Product> GetProducts(string page)
        {
            var products = new List<Product>();
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(page);

            var nodes = htmlDocument.DocumentNode.Descendants("li")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("ProductPrlist_product__PdoZm  ProductComp_product__Zu7ps")).ToList();

            foreach (var node in nodes)
            {
                var ram = GetRamStorage(node);
                var cache = GetCacheStorage(node);
                var monitor = GetMonitorSize(node);
                var hdd = GetHddStorage(node);

                //products.Add(new Product()
                //{
                //    Code = node.Id,
                //    Name = node.ChildNodes[3].InnerText,
                //    Link = $"http://www.technolife.ir{node.ChildNodes[0].Attributes[1].DeEntitizeValue}",
                //    ImageLink = node.ChildNodes[0].ChildNodes[0].ChildNodes[0].Attributes[0].DeEntitizeValue,
                //    LastUpdate = DateTime.Now,
                //    ProductType = ProductType.Laptop,
                //    ProductProvider = ProductProvider.TechnoLife,
                //    MonitorSize = node.ChildNodes[4].ChildNodes[0].ChildNodes[0].InnerText,
                //    ProcessorCache = node.ChildNodes[4].ChildNodes[0].ChildNodes[1].InnerText,
                //    Ram = node.ChildNodes[4].ChildNodes[0].ChildNodes[2].InnerText,
                //    Hdd = node.ChildNodes[4].ChildNodes[0].ChildNodes[3].InnerText,
                //    NormalPrice = node.ChildNodes[5].ChildNodes[0].ChildNodes[0].InnerText,
                //    SellPrice = node.ChildNodes[5].ChildNodes[1].ChildNodes[0].InnerText,
                //});
            }

            return products;
        }

        private string GetCacheStorage(HtmlNode node)
        {
            var cacheStorage = string.Empty;
            var cacheNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-processors")).ToList();
            if (cacheNode.Count() > 0)
            {
                cacheStorage = cacheNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return cacheStorage;
        }

        private string GetMonitorSize(HtmlNode node)
        {
            var monitorSize = string.Empty;
            var monitorNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-monitor")).ToList();
            if (monitorNode.Count() > 0)
            {
                monitorSize = monitorNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return monitorSize;
        }

        private string GetRamStorage(HtmlNode node)
        {
            var ramStorage = string.Empty;
            var ramNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-ram")).ToList();
            if (ramNode.Count() > 0)
            {
                ramStorage = ramNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return ramStorage;
        }

        private string GetHddStorage(HtmlNode node)
        {
            var hddStorage = string.Empty;
            var hddNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-hard-disk-drive")).ToList();
            if (hddNode.Count() > 0)
            {
                hddStorage = hddNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return hddStorage;
        }

        private string GetSellPrice(HtmlNode node)
        {
            var hddStorage = string.Empty;
            var hddNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-hard-disk-drive")).ToList();
            if (hddNode.Count() > 0)
            {
                hddStorage = hddNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return hddStorage;
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
