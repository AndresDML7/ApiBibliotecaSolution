using ApiBiblioteca.Models;

namespace ApiBiblioteca.Repositories
{
    public interface IBibliotecaRepository
    {
        Task<IEnumerable<Libro>> ObtenerLibros();
        Task<IEnumerable<AutorLibro>> ObtenerAutores();
        Task<IEnumerable<Ciudad>> ObtenerCiudades();
    }
}
