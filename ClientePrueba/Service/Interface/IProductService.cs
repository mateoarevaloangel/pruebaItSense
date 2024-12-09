using ClientePrueba.Model;

namespace ClientePrueba.Service.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
    }
}
