using System;

namespace AL.Aplicacion.Entidades;

//No se si es mejor que se llame Publicacion en vez de Alojamiento?
public class Alojamiento
{
    public int Id { get; set; }
    public String? Nombre { get; set; }
    public String? Ciudad { get; set; }
    public String? Direccion { get; set; }
    public int CapacidadMaxima { get; set; }
    public int CantidadDormitorios { get; set; }
    public int CantidadCamas { get; set; }
    public int CantidadBaños { get; set; }
    public String? Descripcion { get; set; }
    public String? Servicios { get; set; }
    public double PrecioPorNoche { get; set; }
    public List<String> Imagenes { get; set; } = new List<string>();
    public List<Reserva> Reservas { get; set; } = new List<Reserva>();

}
