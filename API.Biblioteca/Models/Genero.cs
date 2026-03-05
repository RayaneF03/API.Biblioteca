using System.ComponentModel.DataAnnotations;

namespace API.Biblioteca.Models
{
    public class Genero
    {
        public Guid GeneroId { get; set; }
        [Required]
        public string? Nome { get; set; }

        public ICollection<Livro>? Livros { get; set; }

    }
}
