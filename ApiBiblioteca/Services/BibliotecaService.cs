using ApiBiblioteca.Models;
using ApiBiblioteca.Repositories;

namespace ApiBiblioteca.Services
{
    public class BibliotecaService : IBibliotecaService
    {
        private readonly IBibliotecaRepository _repositorio;

        public BibliotecaService(IBibliotecaRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<ClaseResultado>> ObtenerResultados()
        {
            var libros = await _repositorio.ObtenerLibros();
            var autores = await _repositorio.ObtenerAutores();
            var ciudades = await _repositorio.ObtenerCiudades();

            var result = from l in libros
                         join a in autores on l.AutorId equals a.AutorId
                         group l by a.Nombre into g
                         select new ClaseResultado()
                         {
                             Nombre = g.Key,
                             Total = g.Count()
                         };

            return result.Any() ? result.ToList() : new List<ClaseResultado>();
        }

        public async Task<IEnumerable<LibroCiudadDTO>> ObtenerLibrosConCiudades()
        {
            var libros = await _repositorio.ObtenerLibros();
            var autores = await _repositorio.ObtenerAutores();
            var ciudades = await _repositorio.ObtenerCiudades();

            var result = from libro in libros
                         join autor in autores on libro.AutorId equals autor.AutorId
                         join ciudad in ciudades on autor.CiudadId equals ciudad.CiudadId
                         select new LibroCiudadDTO()
                         {
                             NombreLibro = libro.Nombre,
                             NombreCiudad = ciudad.Nombre
                         };

            return result.ToList();
        }
    }
}
