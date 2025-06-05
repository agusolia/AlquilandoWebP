using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using AL.Aplicacion.Excepciones;
using System.Text.Json;

namespace AL.Aplicacion.CasosDeUso;

public class ReservaAlta
{
    private readonly IReservasRepositorio _reservasRepositorio;
    private readonly ITarjetaRepositorio _tarjetaRepositorio;
    private readonly IServicioSesion _sesion;
    private readonly IUsuarioRepositorio _usuarioRepositorio;
    private readonly IServicioPago _servicioPago;

    public ReservaAlta(IReservasRepositorio reservasRepo, ITarjetaRepositorio tarjetaRepo, IServicioSesion sesion, IUsuarioRepositorio usuarioRepo, IServicioPago servicioPago)
    {
        _reservasRepositorio = reservasRepo;
        _tarjetaRepositorio = tarjetaRepo;
        _sesion = sesion;
        _usuarioRepositorio = usuarioRepo;
        _servicioPago = servicioPago;
    }
    public string Ejecutar(Reserva reserva)
    {
        var usuario = _usuarioRepositorio.ObtenerPorId(_sesion.Id);
        if (usuario == null)
            throw new Exception("Usuario no encontrado");

        var tarjeta = _tarjetaRepositorio.ObtenerPorId(usuario.TarjetaId);
        if (tarjeta == null)
            throw new ValidacionException("No se encontró la tarjeta del usuario");

        bool pagoExitoso = _servicioPago.ValidarPago(tarjeta);
        if (!pagoExitoso)
            return "Reserva rechazada por error en el pago";

        // Asigna usuario
        reserva.IdUsuario = usuario.Id;

        // Establece estado según si tiene fotos cargadas
        if (reserva.ListaInformacionAdicional != null && reserva.ListaInformacionAdicional.Count > 0)
        {
            reserva.EstadoReserva = "Pendiente";
        }
        else
        {
            reserva.EstadoReserva = "Confirmada";
        }

        _reservasRepositorio.Agregar(reserva);

        return reserva.EstadoReserva == "Pendiente"
            ? "La solicitud de reserva fue enviada"
            : "Reserva exitosa";
    }
      
}