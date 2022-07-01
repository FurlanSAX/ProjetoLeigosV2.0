using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Pessoa
    {
        [Key]
        public int idPessoa { get; set; }

        [Required]
        [Display(Name ="Nome")]
        public string? nomePessoa { get; set; }

        [Display(Name = "CPF")]
        public string? cpfPessoa { get; set; }

        [Display(Name = "RG")]
        public string? rgPessoa { get; set; }

        [Display(Name = "Telefone")]
        public string? telefonePessoa { get; set; }

        [Display(Name = "Email")]
        public string? emailPessoa { get; set; }

        [Display(Name = "Senha")]
        public string? senhaPessoa { get; set; }

        [Display(Name = "Genêro")]
        public int idGenero { get; set; }

        [Display(Name ="Endereço")]
        public int idEndereco { get; set; }
        public DateTime dataCadastroPessoa { get; set; } = DateTime.Now;
    }
}
