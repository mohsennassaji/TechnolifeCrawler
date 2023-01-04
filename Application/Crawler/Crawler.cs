using Application.Services;
using Application.TechnoLifeCrawler.PageParser;
using Application.TechnoLifeCrawler.ProductScraper;
using Domain.Enums;
using Domain.TechnoLifeProducts;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Application.Crawler
{
    public class Crawler : ICrawler
    {
        private readonly IProductListParser _technoLifePageParser;
        private readonly IProductParser _technoLifeProductScraper;
        private readonly IDatabaseService _databaseService;
        private readonly ILogManagmentService _log;
        private static volatile HttpClient _httpClient;
        

        public Crawler(IProductListParser technoLifePageParser, IProductParser technoLifeProductScraper, IDatabaseService databaseService, ILogManagmentService log)
        {
            _technoLifePageParser = technoLifePageParser;
            _technoLifeProductScraper = technoLifeProductScraper;
            _databaseService = databaseService;
            _log = log;

            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _httpClient = new HttpClient(handler);
        }
        public async Task Crawl(string url, CancellationToken cancellationToken)
        {
            try
            {
                var crawledProducts = await ExtractProducts(url, cancellationToken);

                var technoLifeLaptopProducts = await _databaseService.Products
                    .Where(p => p.ProductProvider == ProductProvider.TechnoLife 
                    && p.ProductType == ProductType.Laptop).ToListAsync();

                RemoveNotExistedProducts(technoLifeLaptopProducts, crawledProducts);

                var tasks = new List<Task>();
                foreach (var product in crawledProducts)
                {
                    tasks.Add(SaveProduct(product, technoLifeLaptopProducts, cancellationToken));
                }

                await Task.WhenAll(tasks);
            }
            catch(Exception ex)
            {
                _log.Log(ex, this.GetType().ToString(),  System.Reflection.MethodBase.GetCurrentMethod(), "Crawler");
                throw;
            }
        }

        private async Task SaveProduct(Product product, List<Product> availableProducts, CancellationToken cancellationToken)
        {
            var existedProduct = availableProducts.SingleOrDefault(p => p.Code == product.Code);
            if (existedProduct != default)
            {
                existedProduct.LastUpdate = DateTime.Now;
                existedProduct.IsAvailable = product.IsAvailable;
                existedProduct.NormalPrice = product.NormalPrice;
                existedProduct.SellPrice = product.SellPrice;
                existedProduct.DicsountPersentage = product.DicsountPersentage;

                _databaseService.Products.Update(existedProduct);
            }
            else
            {
                await _databaseService.Products.AddAsync(product, cancellationToken);
            }

            await _databaseService.SaveChangesAsync(cancellationToken);

            await _technoLifeProductScraper.SaveProductImages(product);
            await _technoLifeProductScraper.SaveProductSpecification(product);
        }

        private void RemoveNotExistedProducts(List<Product> technoLifeLaptopProducts, List<Product> crawledProducts)
        {
            var productsCode = crawledProducts.Select(p => p.Code).ToList();
            var notExistedAnyMore = technoLifeLaptopProducts.Where(p => !productsCode.Contains(p.Code)).ToList();
            _databaseService.Products.RemoveRange(notExistedAnyMore);
        }

        private async Task<List<Product>> ExtractProducts(string url, CancellationToken cancellationToken)
        {
            var products = new List<Product>();

            var i = 1;
            while (true)
            {
                var pageUrl = $"{url}?page={i}";
                var webPage = await _httpClient.GetStringAsync(pageUrl, cancellationToken);
                products.AddRange(_technoLifePageParser.GetProducts(webPage));

                var maximumPageNumber = _technoLifePageParser.GetMaximumActivePageNumber(webPage);
                if (i >= maximumPageNumber)
                {
                    break;
                }

                i++;
            }

            return products;
        }
    }
}
