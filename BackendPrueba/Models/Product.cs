using System.Reflection;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendPrueba.Models
{
    public class Product
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public Status? Status { get; set; }
        public int TypeManofacture { get; set; }
        public int Stock { get; set; }
    }
}
