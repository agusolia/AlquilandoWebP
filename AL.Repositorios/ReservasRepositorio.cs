using System;
using Microsoft.EntityFrameworkCore;
using AL.Aplicacion.Entidades;
using AL.Aplicacion.Interfaces;
using System.Text.Json;
namespace AL.Repositorios;

public class ReservasRepositorio: IReservasRepositorio
{
//Caso de uso reserva ALTA
    public void Agregar(Reserva r){
        
        using(var db=new EntidadesContext()){  
            db.Add(r);
            db.SaveChanges();
        }
    }

    //Caso de uso reserva BAJA
    public void Eliminar(Reserva r){
        using(var db=new EntidadesContext()){  
            var reserva = db.Reservas.Where(re => re.Id == r.Id).SingleOrDefault();
            if(reserva != null){
                 db.Remove(reserva);
                 db.SaveChanges();
        }
        }
    }

    //Caso de uso Consulta por Id
    public Reserva? ObtenerPorId(int id){
        using(var db=new EntidadesContext()){  
            var reservas = db.Reservas.Where(r => r.Id == id).SingleOrDefault();
            return reservas;
        }
    } 
    
    //Caso de uso consulta TODOS
    public List<Reserva> ObtenerTodas(){
        using (var db=new EntidadesContext()){
            List<Reserva> resultado = db.Reservas.ToList();
            foreach (var res in resultado)
            {
                if (!string.IsNullOrWhiteSpace(res.InformacionInquilinos))
                {
                    try
                    {
                        res.Inquilinos = JsonSerializer.Deserialize<List<Inquilino>>(res.InformacionInquilinos) ?? new();
                    }
                    catch
                    {
                        res.Inquilinos = new();
                    }
                }
            }
            return resultado;  
        }
    }
    public List<Reserva> ObtenerReservasPorAlojamientoId(int alojamientoId)
    {
        using (var db = new EntidadesContext())
        {
            return db.Reservas.Where(r => r.IdAlojamiento == alojamientoId).ToList();
        }
    }
    public List<Reserva> ObtenerReservasPorUsuarioId(int usuarioId)
    {
        using (var db = new EntidadesContext())
        {
            return db.Reservas.Where(r => r.IdUsuario == usuarioId).ToList();
        }
    }

    //Caso de uso reserva MODIFICACION (puede que no se use)
    public void Modificar(Reserva r)
    {
        using (var db = new EntidadesContext())
        {
            db.Reservas.Update(r);
            db.SaveChanges();
        }
    }
}
