using Application.Services;
using Application.TechnoLifeCrawler.PageParser;
using Application.TechnoLifeCrawler.ProductScraper;
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
        public async Task Crawl(string url)
        {
            try
            {
                var tasks = new List<Task>();
                var i = 1;
                while (true)
                {
                    var webPage = await _httpClient.GetStringAsync($"{url}?page={i}");
                    var products = await _technoLifePageParser.Parse(webPage);

                    var productsCode = products.Select(p => p.Code).ToList();
                    var availableProducts = await _databaseService.Products.Where(p => productsCode.Contains(p.Code)).ToListAsync();

                    foreach (var product in products)
                    {
                        tasks.Add(SaveProduct(product, availableProducts));
                    }

                    var maximumPageNumber = await _technoLifePageParser.GetMaximumActivePageNumber(webPage);
                    if (i >= maximumPageNumber)
                    {
                        break;
                    }

                    i++;
                }

                await Task.WhenAll(tasks);
            }
            catch(Exception ex)
            {
                _log.Log(ex, this.GetType().ToString(),  System.Reflection.MethodBase.GetCurrentMethod(), "Crawler");
                throw;
            }
        }

        private async Task SaveProduct(Product product, List<Product> availableProducts)
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
                await _databaseService.Products.AddAsync(product);
            }

            await _databaseService.SaveChangesAsync(CancellationToken.None);

            await _technoLifeProductScraper.SaveProductImages(product);
            await _technoLifeProductScraper.SaveProductSpecification(product);
        }
    }
}
