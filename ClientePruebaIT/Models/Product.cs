namespace ClientePruebaIT.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Product
    {
        [Display(Name="#")]
        public int ProductId { get; set; }
        [Display(Name = "Nombre Producto")]
        public string? Name { get; set; }
        [Display(Name = "Estado")]
        public int Status { get; set; }
        [Display(Name = "Tipo")]
        public int TypeManofacture { get; set; }
        [Display(Name = "Stock")]
        public int Stock { get; set; }
    }
}
