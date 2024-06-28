using ApiBiblioteca.Models;

namespace ApiBiblioteca.Services
{
    public interface IBibliotecaService
    {
        Task<IEnumerable<ClaseResultado>> ObtenerResultados();
        Task<IEnumerable<LibroCiudadDTO>> ObtenerLibrosConCiudades();
    }
}
