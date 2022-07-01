using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Endereco
    {
        [Key]
        public int idEnd { get; set; }
        
        [Required]
        [Display(Name ="CEP")]
        public string? cep { get; set; }
        
        [Display(Name = "Rua")]
        public string? rua { get; set; }
        
        [Display(Name = "Nº")]
        public int numero { get; set; }

        [Display(Name = "Bairro")]
        public string? bairro { get; set; }

        [Display(Name = "Cidade")]
        public string? cidade { get; set; }

        [Display(Name = "UF")]
        public string? uf { get; set; }
    }
}
