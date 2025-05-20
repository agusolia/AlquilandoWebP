using System;
using AL.Aplicacion.Entidades;

namespace AL.Aplicacion.Interfaces;

public interface IAlojamientoRepositorio
{
    void Agregar(Alojamiento alojamiento);
    void Eliminar(Alojamiento alojamiento);
    void Modificar(Alojamiento alojamiento);
    Alojamiento? ObtenerPorId(int id);
    List <Alojamiento> ObtenerTodos();
    public List<Alojamiento> ListarAlojamientosConSusReservas();    
}
