using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Servico
    {
        [Key]
        public int idServico { get; set; }


        [Required]
        [Display(Name ="Nome")]
        public string? nomeServico { get; set; }


        [Display(Name ="Breve Descrição")]
        public string? descricacaoServico { get; set; }


        [Display(Name ="Categoria")]
        public int idCategoria { get; set; }


        [Display(Name ="Avaliação")]
        public float notaServico { get; set; }
    }
}
