using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Pessoa>? Pessoa { get; set; }
        public DbSet<WebApplication1.Models.Genero>? Genero { get; set; }
        public DbSet<WebApplication1.Models.Categoria>? Categoria { get; set; }
        public DbSet<WebApplication1.Models.Endereco>? Endereco { get; set; }
        public DbSet<WebApplication1.Models.Servico>? Servico { get; set; }
    }
}