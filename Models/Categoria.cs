using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Required]
        [Display(Name ="Nome")]
        public string? nomeCategoria { get; set; }
    }
}
