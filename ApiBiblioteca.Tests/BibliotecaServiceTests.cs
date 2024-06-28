using ApiBiblioteca.Models;
using ApiBiblioteca.Repositories;
using ApiBiblioteca.Services;
using AutoFixture;
using Moq;

namespace ApiBiblioteca.Tests;

public class BibliotecaServiceTests
{
    private readonly IFixture _fixture;
    private readonly Mock<IBibliotecaRepository> _repositorioMock;
    private readonly BibliotecaService _servicio;

    public BibliotecaServiceTests()
    {
        _fixture = new Fixture();
        _repositorioMock = new Mock<IBibliotecaRepository>();
        _servicio = new BibliotecaService(_repositorioMock.Object);
    }

    [Fact]
    public async Task ObtenerResultados_DeberiaRetornarResultadosCorrectos()
    {
        var libros = _fixture.CreateMany<Libro>(10).ToList();
        var autores = _fixture.CreateMany<AutorLibro>(5).ToList();
        var ciudades = _fixture.CreateMany<Ciudad>(5).ToList();

        _repositorioMock.Setup(r => r.ObtenerLibros()).ReturnsAsync(libros);
        _repositorioMock.Setup(r => r.ObtenerAutores()).ReturnsAsync(autores);
        _repositorioMock.Setup(r => r.ObtenerCiudades()).ReturnsAsync(ciudades);

        var resultados = await _servicio.ObtenerResultados();

        Assert.NotEmpty(resultados);
        Assert.True(resultados.All(r => r.Total > 0));
    }

    [Fact]
    public async Task ObtenerResultados_DeberiaRetornarListaVaciaSiNoHayResultados()
    {
        _repositorioMock.Setup(r => r.ObtenerLibros()).ReturnsAsync(new List<Libro>());
        _repositorioMock.Setup(r => r.ObtenerAutores()).ReturnsAsync(new List<AutorLibro>());
        _repositorioMock.Setup(r => r.ObtenerCiudades()).ReturnsAsync(new List<Ciudad>());

        var resultados = await _servicio.ObtenerResultados();

        Assert.Empty(resultados);
    }
}