using AL.Aplicacion.Interfaces;
namespace AL.Aplicacion.CasosDeUso;

public class DesarchivarPublicacionCasoDeUso
{
    private readonly IAlojamientoRepositorio _alojamientoRepositorio;

    public DesarchivarPublicacionCasoDeUso(IAlojamientoRepositorio alojamientoRepositorio)
    {
        _alojamientoRepositorio = alojamientoRepositorio;
    }

    public async Task Ejecutar(int alojamientoId)
    {
        var alojamiento = await _alojamientoRepositorio.ObtenerPorId(alojamientoId);

        alojamiento.Estado = Enumerativos.EstadoPublicacion.Publicado;
        _alojamientoRepositorio.Modificar(alojamiento);
    }
}
