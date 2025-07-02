using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.CasosDeUso;

public class ReservaConsultaTodos(IReservasRepositorio reservasRepo,IServicioChat ServicioChat) : ReservaCasoDeUso(reservasRepo)
{
    public List<Reserva> Ejecutar(int idUsuario)
    {
        List<Reserva> reservas = Repositorio.ObtenerTodos();
        foreach (var reserva in reservas)
        {
            reserva.MensajesNoLeidos= ServicioChat.ObtenerCantidadNoLeidosAsync(idUsuario, reserva.Id).Result;
    
        }
        return reservas;
    }
}
