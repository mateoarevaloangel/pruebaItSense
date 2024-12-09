using ClientePrueba.Model;
using ClientePrueba.Service.Interface;
using System.Net.Http;

namespace ClientePrueba.Service.Service
{
    public class ProductService: IProductService
    {
        private readonly HttpClient httpClient;
        public ProductService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await httpClient.GetFromJsonAsync<Product[]>("api/products");
        }
    }
}
