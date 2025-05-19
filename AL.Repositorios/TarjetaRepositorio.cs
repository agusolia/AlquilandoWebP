using System;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
namespace AL.Repositorios;

public class TarjetaRepositorio: ITarjetaRepositorio
{
    public int Agregar(Tarjeta t)
    {
        using (var db = new EntidadesContext())
        {
            db.Tarjetas.Add(t);
            db.SaveChanges();
            return t.Id;
        }
    }
}
