using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppProject.Models;

namespace WebAppProject.Services
{
    public class ProductService
    {
        private readonly RestClient _client;

        public ProductService()
        {
            _client = new RestClient("http://webapi:80/api/products");  // URL ของ Web API
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var request = new RestRequest();
            var response = await _client.ExecuteAsync<List<Product>>(request, Method.Get);
            return response.Data ?? new List<Product>();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var request = new RestRequest("/{id}").AddUrlSegment("id", id);
            var response = await _client.ExecuteAsync<Product>(request, Method.Get);
            return response.Data;
        }

        public async Task AddProductAsync(Product product)
        {
            var request = new RestRequest().AddJsonBody(product);
            await _client.ExecuteAsync(request, Method.Post);
        }

        public async Task UpdateProductAsync(Product product)
        {
            var request = new RestRequest("/{id}")
                .AddUrlSegment("id", product.Id)
                .AddJsonBody(product);
            await _client.ExecuteAsync(request, Method.Put);
        }

        public async Task DeleteProductAsync(int id)
        {
            var request = new RestRequest("/{id}").AddUrlSegment("id", id);
            await _client.ExecuteAsync(request, Method.Delete);
        }
    }
}
