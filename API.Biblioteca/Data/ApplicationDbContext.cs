using API.Biblioteca.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Biblioteca.Data
{
    // Contexto de banco de dados para a aplicação, utilizando IdentityDbContext para suporte à autenticação e autorização
    public class ApplicationDbContext : IdentityDbContext
    {
        // Construtor que recebe as opções de configuração do DbContext 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet para a entidade Genero, permitindo operações de CRUD no banco de dados para essa entidade
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Livro> Livro { get; set; }
        public DbSet<LivroGenero> LivroGenero { get; set; }
    }
}