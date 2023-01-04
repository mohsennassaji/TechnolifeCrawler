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
                var product = new Product();
                product.Ram = GetRamStorage(node);
                product.ProcessorCache = GetCacheStorage(node);
                product.MonitorSize = GetMonitorSize(node);
                product.Hdd = GetHddStorage(node);
                product.IsAvailable = GetProductIsAvailable(node);
                if(product.IsAvailable)
                {
                    product.NormalPrice = GetNormalPrice(node);
                    product.SellPrice = GetOfferPrice(node);
                    product.DicsountPersentage = GetDiscount(node);
                }
                
                product.ImageLink = GetImageLink(node);
                product.Link = GetProductLink(node);
                product.Code = node.Id;
                product.Name = node.ChildNodes[0].Attributes[0].Value;
                product.LastUpdate = DateTime.Now;
                product.ProductProvider = ProductProvider.TechnoLife;
                product.ProductType = ProductType.Laptop;

                products.Add(product);
            }

            return products;
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

        private string GetProductLink(HtmlNode node)
        {
            return $"http://www.technolife.ir{node.ChildNodes[0].Attributes[1].DeEntitizeValue}";
        }

        private string GetImageLink(HtmlNode node)
        {
            var imageLink = string.Empty;
            var imageLinkNode = node.ChildNodes.Descendants("img")
                .ToList();
            if (imageLinkNode.Count() > 0)
            {
                imageLink = imageLinkNode.First().Attributes[0].Value;
            }

            return imageLink;
        }

        private string? GetCacheStorage(HtmlNode node)
        {
            string? cacheStorage = null;
            var cacheNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-processors")).ToList();
            if (cacheNode.Count() > 0)
            {
                cacheStorage = cacheNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return cacheStorage;
        }

        private string? GetMonitorSize(HtmlNode node)
        {
            string? monitorSize = null;
            var monitorNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-monitor")).ToList();
            if (monitorNode.Count() > 0)
            {
                monitorSize = monitorNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return monitorSize;
        }

        private string? GetRamStorage(HtmlNode node)
        {
            string? ramStorage = null;
            var ramNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-ram")).ToList();
            if (ramNode.Count() > 0)
            {
                ramStorage = ramNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return ramStorage;
        }

        private string? GetHddStorage(HtmlNode node)
        {
            string? hddStorage = null;
            var hddNode = node.ChildNodes[4].ChildNodes[0].ChildNodes.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("icon-hard-disk-drive")).ToList();
            if (hddNode.Count() > 0)
            {
                hddStorage = hddNode.First().ParentNode.ChildNodes[1].InnerText;
            }

            return hddStorage;
        }

        private bool GetProductIsAvailable(HtmlNode node)
        {
            var isAvailable = true;
            var hddNode = node.ChildNodes.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("ProductComp_unavailable_product___76Dc")).ToList();
            if (hddNode.Count() > 0)
            {
                isAvailable = false;
            }

            return isAvailable;
        }

        private decimal GetNormalPrice(HtmlNode node)
        {
            var normalPrice = string.Empty;
            var normalPriceNode = node.ChildNodes.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("ProductComp_normal_price__Upie4")).ToList();

            if(normalPriceNode.Count() == 0)
            {
                normalPriceNode = node.ChildNodes.Descendants("div")
                    .Where(node => node.GetAttributeValue("class", "").Equals("ProductComp_main_price__XgWce")).ToList();
            }

            if (normalPriceNode.Count() > 0)
            {
                normalPrice = normalPriceNode.First().ChildNodes[0].ChildNodes[0].InnerText;
            }

            return string.IsNullOrEmpty(normalPrice) == true ? default : decimal.Parse(RemoveNoneDigitChars(normalPrice));
        }

        private decimal GetOfferPrice(HtmlNode node)
        {
            var offerPrice = string.Empty;
            var offerPriceNode = node.ChildNodes.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("ProductComp_offer_price__HAQ6N")).ToList();

            if (offerPriceNode.Count() > 0)
            {
                offerPrice = offerPriceNode.First().ChildNodes[0].ChildNodes[0].InnerText;
            }

            return string.IsNullOrEmpty(offerPrice) == true ? default : decimal.Parse(RemoveNoneDigitChars(offerPrice));
        }

        private float GetDiscount(HtmlNode node)
        {
            //TODO: Fix bug
            var discount = string.Empty;
            var discountNode = node.ChildNodes.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "").Equals("ProductComp_product_off_box__OfLBa")).ToList();
            if (discountNode.Count() > 0)
            {
                discount = discountNode.First().ChildNodes[0].ChildNodes[0].InnerText;
            }

            return string.IsNullOrEmpty(discount) == true ? default : float.Parse(discount.Substring(0, discount.Length - 1));
        }

        private string RemoveNoneDigitChars(string input)
        {
            return string.Concat(input.Where(char.IsDigit));
        }        
    }
}
