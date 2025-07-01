using System;

namespace AL.Aplicacion.Entidades;

public class Mensaje
{
    public int Id { get; set; }
    public DateTime FechaHora { get; set; }
    public String Texto { get; set; } = string.Empty;
    public int IdUsuarioCreador { get; set; }
    public int IdUsuarioReceptor { get; set; }
    public int IdReserva { get; set; }
}
