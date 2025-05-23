using System;
using AL.Aplicacion.Entidades;
namespace AL.Aplicacion.Validadores;

public static class TarjetaValidador
{
    public static bool Validar(Tarjeta t, out String mensajeError)
    {
        mensajeError = "";
        if (string.IsNullOrWhiteSpace(t.Numero) || t.Numero.Length != 16)
        {
            mensajeError += "El número de tarjeta debe tener 16 dígitos.\n";
        }
        if (String.IsNullOrWhiteSpace(t.NombreTitular))
        {
            mensajeError += "El nombre del titular no puede estar vacío.\n";
        }
        if (String.IsNullOrWhiteSpace(t.FechaVencimiento))
        {
            mensajeError += "La fecha de vencimiento no puede estar vacía.\n";
        }
        if (t.CodigoSeguridad.ToString().Length != 3)
        {
             mensajeError += "El código de seguridad debe tener 3 dígitos.\n";
        }
        return (mensajeError == "");    
    }
    

}
