using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Genero
    {
        [Key]
        public int idGenero { get; set; }
        [Display(Name ="Genero")]
        public string? GeneroNome { get; set; }
    }
}
