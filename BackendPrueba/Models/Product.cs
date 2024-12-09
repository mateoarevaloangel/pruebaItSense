using System.Reflection;

namespace BackendPrueba.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public int TypeManofacture { get; set; }
        public int Stock { get; set; }
    }
}
