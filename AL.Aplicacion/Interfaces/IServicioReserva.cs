using System;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.Interfaces;

public interface IServicioReserva
{
    public List<Reserva> ObtenerReservasDelUsuario();
    public String SolicitarReserva(Reserva reserva);
    public string CancelarReservaConDemanda(int idReserva);
}
