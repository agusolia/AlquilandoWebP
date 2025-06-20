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
    [Required(ErrorMessage = "Ingrese al menos un adulto.")]
    [Range(1, int.MaxValue, ErrorMessage = "La cantidad de adultos debe ser al menos 1.")]
    public int? CantidadDeAdultos { get; set; }
    
    [Required(ErrorMessage = "Por favor ingresá la cantidad de niños.")]
    [Range(0, int.MaxValue, ErrorMessage = "La cantidad de niños debe ser igual o mayor a 0")]
    public int? CantidadDeNiños { get; set; }


    public String InformacionInquilinos { get; set; } = string.Empty;
    public List<String> ListaInformacionAdicional { get; set; } = new List<String>();

}
