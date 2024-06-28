using ApiBiblioteca.Models;

namespace ApiBiblioteca.Repositories
{
    public class BibliotecaRepository : IBibliotecaRepository
    {
        public Task<IEnumerable<AutorLibro>> ObtenerAutores()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Ciudad>> ObtenerCiudades()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Libro>> ObtenerLibros()
        {
            throw new NotImplementedException();
        }
    }
}
