using System;

namespace AL.Aplicacion.Entidades;

public class Alojamiento
{
    public int Id { get; set; }
    public String? Nombre { get; set; }
    public String? Direccion { get; set; }
    public int CapacidadMaxima { get; set; }
    public int CantidadDormitorios { get; set; }
    public int CantidadCamas { get; set; }
    public int CantidadBaños { get; set; }
    public String? Descripcion { get; set; }
    public String? Servicios { get; set; }
    public List<String> FotosDelAlojamiento { get; set; } = new List<string>();


}
