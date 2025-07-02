using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;

namespace AL.Aplicacion.CasosDeUso;

public class ReservaConsultaTodosPorUsuario(IReservasRepositorio repositorio) : ReservaCasoDeUso(repositorio)
{
    public List<Reserva> Ejecutar(int usuarioId)
    {
        List<Reserva> reservas = Repositorio.ObtenerReservasPorUsuarioId(usuarioId);
        return reservas;
    }
}
