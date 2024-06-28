namespace ApiBiblioteca.Models
{
    public class Libro
    {
        public int LibroId { get; set; }
        public string Nombre { get; set; }
        public int AnioPublicacion { get; set; }
        public int AutorId { get; set; }
    }
}
