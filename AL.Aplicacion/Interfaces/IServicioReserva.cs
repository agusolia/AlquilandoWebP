using System;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.Interfaces;

public interface IServicioReserva
{
    public List<Reserva> ObtenerReservasDelUsuario();
    Task  <string> SolicitarReserva(Reserva reserva);
    public string CancelarReservaConDemanda(int idReserva);
}
