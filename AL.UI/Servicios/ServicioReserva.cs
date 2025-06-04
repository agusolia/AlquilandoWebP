using AL.Aplicacion.CasosDeUso;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using System;
using System.Linq;
namespace AL.UI.Servicios;

public class ServicioReserva : IServicioReserva
{
    private readonly IReservasRepositorio _reservasRepositorio;
    private readonly IAlojamientoRepositorio _alojamientoRepositorio;
    private readonly ITarjetaRepositorio _tarjetaRepositorio;
    private readonly IServicioSesion _sesion;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IServicioPago _servicioPago;

    public ServicioReserva(IReservasRepositorio reservasRepositorio, IAlojamientoRepositorio alojamientoRepositorio, ITarjetaRepositorio tarjetaRepositorio, IServicioSesion sesion, IUsuarioRepositorio usuarioRepositorio, IServicioPago servicioPago)
    {
        _reservasRepositorio = reservasRepositorio;
        _alojamientoRepositorio = alojamientoRepositorio;
        _tarjetaRepositorio = tarjetaRepositorio;
        _sesion = sesion;
        _usuarioRepositorio = usuarioRepositorio;
        _servicioPago = servicioPago;
    }

    public List<Reserva> ObtenerReservasDelUsuario()
    {
        return _reservasRepositorio.ObtenerReservasPorUsuarioId(_sesion.Id);
    }

    public string SolicitarReserva(Reserva reserva)
    {
        reserva.IdUsuario = _sesion.Id;

        var reservaAlta = new ReservaAlta(
            _reservasRepositorio,
            _tarjetaRepositorio,
            _sesion,
            _usuarioRepositorio,
            _servicioPago
        );
        return reservaAlta.Ejecutar(reserva);
    }
    public string CancelarReservaConDemanda(int idReserva)
    {
        var reserva = _reservasRepositorio.ObtenerPorId(idReserva);
        if (reserva == null)
            return "Reserva no encontrada.";

        if (DateTime.Now >= reserva.FechaInicioEstadia)
            return "No se puede cancelar una reserva ya iniciada.";

        var reservasAlojamiento = _reservasRepositorio.ObtenerReservasPorAlojamientoId(reserva.IdAlojamiento);

        var reservasEnFecha = reservasAlojamiento
            .Where(r =>
                DateTime.Now < r.FechaFinEstadia &&
                r.FechaInicioEstadia < reserva.FechaFinEstadia &&
                r.FechaFinEstadia > reserva.FechaInicioEstadia)
            .Count();

        double montoReembolso = reservasEnFecha > 5
            ? reserva.MontoEstadia * 0.5
            : reserva.MontoEstadia;

        _reservasRepositorio.Eliminar(reserva);

        return $"Reserva cancelada. Reembolso: ${montoReembolso}";
    }
}