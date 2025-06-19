namespace AL.Aplicacion.Entidades;

using System.ComponentModel.DataAnnotations;

public class Reserva
{
    public int Id { get; set; }
    public int IdAlojamiento { get; set; }
    public int IdUsuario { get; set; }
    public DateTime FechaInicioEstadia { get; set; }
    public DateTime FechaFinEstadia { get; set; }
    public double MontoEstadia { get; set; }
    public String? EstadoCheckOut { get; set; }
    public String? EstadoReserva { get; set; }
    public int CantidadDeAdultos { get; set; }
    public int CantidadDeNiños { get; set; }
    public String InformacionInquilinos { get; set; } = string.Empty;
    public List<String> ListaInformacionAdicional { get; set; } = new List<String>();

}
