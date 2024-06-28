using ApiBiblioteca.Models;
using ApiBiblioteca.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecaService _servicio;

        public BibliotecaController(IBibliotecaService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("resultados")]
        public async Task<ActionResult<IEnumerable<ClaseResultado>>> GetResultados()
        {
            var resultados = await _servicio.ObtenerResultados();
            return Ok(resultados);
        }

        [HttpGet("libros-con-ciudades")]
        public async Task<ActionResult<IEnumerable<LibroCiudadDTO>>> GetLibrosConCiudades()
        {
            var librosConCiudades = await _servicio.ObtenerLibrosConCiudades();
            return Ok(librosConCiudades);
        }
    }
}
