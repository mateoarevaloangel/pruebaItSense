using System.ComponentModel.DataAnnotations.Schema;

namespace BackendPrueba.Models
{
    public class User
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Pasword { get; set; }
    }
}
