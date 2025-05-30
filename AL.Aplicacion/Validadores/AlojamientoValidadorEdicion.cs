using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Aplicacion.Validadores;

public  class AlojamientoValidadorEdicion(IAlojamientoRepositorio _alojamientoRepo):IAlojamientoValidadorEdicion
{

    public  bool Validar(Alojamiento a, out string mensajeError, String? nombreOriginal)
    {
        mensajeError = "";
        var alojamientoExistente = _alojamientoRepo.ObtenerPorNombre(a.Nombre);
        if (alojamientoExistente != null && !alojamientoExistente.Nombre.Equals(nombreOriginal))
        {
            mensajeError = "El nombre del alojamiento ingresado ya existe.";
        }
        if (string.IsNullOrWhiteSpace(a.Nombre))
        {
            mensajeError = "El nombre no puede estar vacio.";
        }
        if (string.IsNullOrWhiteSpace(a.Ciudad))
        {
            mensajeError = "La ciudad no puede estar vacia.";
        }
        if (string.IsNullOrWhiteSpace(a.Direccion))
        {
            mensajeError = "Debe ingresar la dirección.";
        }
        if (a.CapacidadMaxima <= 0)
        {
            mensajeError = "Debe ingresar la capacidad máxima.";
        }
        if (a.CantidadDormitorios <= 0)
        {
            mensajeError = "Debe ingresar la cantidad de dormitorios.";
        }
        if (a.CantidadBaños <= 0)
        {
            mensajeError = "Debe ingresar la cantidad de baños.";
        }
        if (a.CantidadCamas <= 0)
        {
            mensajeError = "Debe ingresar la cantidad de camas.";
        }
        if (a.PrecioPorNoche < 0)
        {
            mensajeError = "Debe ingresar el precio por noche del alojamiento.";
        }
        return (mensajeError == "");
    }
}
