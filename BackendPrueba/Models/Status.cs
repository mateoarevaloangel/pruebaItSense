using System.ComponentModel.DataAnnotations.Schema;

namespace BackendPrueba.Models
{
    public class Status
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int StatusId { get; set; }
        public String Name { get; set; }
    }
}
