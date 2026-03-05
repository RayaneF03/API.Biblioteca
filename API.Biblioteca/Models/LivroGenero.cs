namespace API.Biblioteca.Models
{
    public class LivroGenero
    {
        public Guid LivroGeneroId { get; set; }
        // Propriedades de navegação para as entidades relacionadas Livro e Genero, permitindo a associação entre um livro e um gênero específico
        public Guid LivroId { get; set; }
        public Livro? Livro { get; set; }  // Objeto Livro é opcional (nullable) para permitir a flexibilidade na associação, caso um livro possa existir sem um gênero específico ou vice-versa
        public Guid GeneroId { get; set; }
        public Genero? Genero { get; set; } // Objeto Genero é opcional (nullable) para permitir a flexibilidade na associação, caso um gênero possa existir sem um livro específico ou vice-versa
    }
}
