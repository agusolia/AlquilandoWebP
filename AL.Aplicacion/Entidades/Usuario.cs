using System;

namespace AL.Aplicacion.Entidades;

public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; } = "";
    public string Apellido { get; set; } = "";
    public int Edad {   get; set; }
    public String CorreoElectronico { get; set; } = "";
    public string HashContraseña { get; set; } = "";
    public string SalContraseña { get; set; } = "";
    public List <Reserva> ListaReservas { get; set; } = new List<Reserva>();
}
