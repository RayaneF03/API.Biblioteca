using System.ComponentModel.DataAnnotations;

namespace API.Biblioteca.Models
{
    public class Livro
    {
        public Guid LivroId { get; set; }
        [Required]
        public string? Titulo { get; set; }
        [Required]
        public string? Autor { get; set; }
        public int AnoPublicacao { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public string? UrlCapa { get; set; }
        public string? Editora { get; set; }
        public string? Edicao { get; set; }

        //propriedade de navegação para a relação muitos-para-muitos entre Livro e Genero, permitindo que um livro possa estar associado a múltiplos gêneros e vice-versa
        public ICollection<Genero>? Generos { get; set; }
    }
}
