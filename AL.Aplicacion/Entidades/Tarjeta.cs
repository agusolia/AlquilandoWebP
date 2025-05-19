using System;
using Microsoft.VisualBasic;

namespace AL.Aplicacion.Entidades;

public class Tarjeta
{
    public int Id { get; set; }
    public int Numero { get; set; }
    public String? NombreTitular { get; set; }
    public DateTime FechaVencimiento { get; set; }
    public int CodigoSeguridad { get; set; }
}
